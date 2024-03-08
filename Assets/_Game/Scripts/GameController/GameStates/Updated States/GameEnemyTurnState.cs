using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnemyTurnState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    private bool _hasAttacked = false;

    public GameEnemyTurnState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        //refresh state UI
        _controller.UIManager.RefreshStateText("EnemyTurnState");

        //update instruction UI
        _controller.UIManager.UpdateInstructionText(StatesUIEnum.EnemyFirst);

        //enable enemy turn controller
        _controller.EnemyTurn.gameObject.SetActive(true);

        //selects a random player city
        _controller.EnemyTurn.ChooseCityToAttack();

        _hasAttacked = false;

        ScoreManager.OnGameOver += SwitchOnGameOver;
    }

    public override void Exit()
    {
        base.Exit();

        //reset the city to be attacked
        _controller.EnemyTurn.ResetCityToAttack();

        //disable enemy turn controller
        _controller.EnemyTurn.gameObject.SetActive(false);

        ScoreManager.OnGameOver -= SwitchOnGameOver;
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        //update fill bar
        _controller.UIManager.UpdateFillAmount(StateDuration, 6.0f);

        if (StateDuration > 3.0f && _hasAttacked == false)
        {
            //update instruction UI
            _controller.UIManager.UpdateInstructionText(StatesUIEnum.EnemySecond);

            //attack the player
            int attackInt = Random.Range(0, 3);
            _controller.EnemyTurn.UseAttackOnCity(attackInt);

            _hasAttacked = true;
        }

        if(StateDuration > 6.0f && _hasAttacked == true)
        {
            //check if anyone has won; if not loop to choose state
            //TODO
            if (ScoreManager.CheckIfGameOver())
            {
                _stateMachine.ChangeState(_stateMachine.GameOverState);
            }
            else
            {
                _stateMachine.ChangeState(_stateMachine.ChooseState);
            }
        }
    }

    private void SwitchOnGameOver()
    {
        _stateMachine.ChangeState(_stateMachine.GameOverState);
    }
}
