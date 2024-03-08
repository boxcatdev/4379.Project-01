using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameChooseState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameChooseState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        //refresh state UI
        _controller.UIManager.RefreshStateText("PlayerChooseState");

        //update instruction UI
        _controller.UIManager.EnableInstructionCanvas(true);
        _controller.UIManager.UpdateInstructionText(StatesUIEnum.Choose);

        //enable manager
        _controller.ChooseManager.gameObject.SetActive(true);

        //reset choices
        ChooseManager.ChosenCitiesCount = 0;

        //increase round
        ScoreManager.CurrentRound++;

        //reset player cities
        _controller.ChooseManager.ResetPlayerCities();

        //setup enemy city defend moves
        _controller.ChooseManager.SetupEnemyDefendMoves();

        //play state change SFX
        _controller.AudioSFX.PlaySoundEffect(SFXType.StateChange);
    }

    public override void Exit()
    {
        base.Exit();

        //disable manager
        _controller.ChooseManager.gameObject.SetActive(false);
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        if(ChooseManager.ChosenCitiesCount >= 6)
        {
            //setup enemy city defend moves
            //moved to enter function

            //move on to next state
            _stateMachine.ChangeState(_stateMachine.PlayerTurnState);
        }
    }
}
