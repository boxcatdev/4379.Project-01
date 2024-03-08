using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerTurnState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlayerTurnState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        //refresh state UI
        _controller.UIManager.RefreshStateText("PlayerTurnState");

        //update instruction UI
        _controller.UIManager.UpdateInstructionText(StatesUIEnum.Player);

        //enable player turn controller
        _controller.PlayerTurn.gameObject.SetActive(true);

        //reset player has attacked
        _controller.PlayerTurn.ResetPlayerHasAttacked();

        ScoreManager.OnGameOver += SwitchOnGameOver;

        //play state change SFX
        _controller.AudioSFX.PlaySoundEffect(SFXType.StateChange);
    }

    public override void Exit()
    {
        base.Exit();

        //disable player turn controller
        _controller.PlayerTurn.gameObject.SetActive(false);

        ScoreManager.OnGameOver -= SwitchOnGameOver;
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        if (_controller.PlayerTurn.PlayerHasAttacked == true)
            _stateMachine.ChangeState(_stateMachine.EnemyTurnState);
    }

    private void SwitchOnGameOver()
    {
        _stateMachine.ChangeState(_stateMachine.GameOverState);
    }
}
