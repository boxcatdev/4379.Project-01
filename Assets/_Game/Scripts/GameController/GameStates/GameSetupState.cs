using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        //refresh state UI
        _controller.UIManager.RefreshStateText("SetupState");

        //hide instruction UI
        _controller.UIManager.EnableInstructionCanvas(false);

        Debug.Log("STATE: Game Setup");
        Debug.Log("Change tiles to green");

        //reset round
        ScoreManager.CurrentRound = 0;

        //turn all the tiles to green
        //_controller.GridModify.ChangeAllTiles();

        //play state change SFX
        _controller.AudioSFX.PlaySoundEffect(SFXType.StateChange);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        //update fill bar
        _controller.UIManager.UpdateFillAmount(StateDuration, 1.5f);

        if (StateDuration > 1.5f)
            _stateMachine.ChangeState(_stateMachine.ChooseState);
    }
}
