using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameWinState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        //refresh state UI
        _controller.UIManager.RefreshStateText("GameWinState");

        // enable win canvas
        _controller.UIManager.EnableWinCanvas(true);

        //play state change SFX
        //_controller.AudioSFX.PlaySoundEffect(SFXType.StateChange);
    }

    public override void Exit()
    {
        base.Exit();

        // enable win canvas
        _controller.UIManager.EnableWinCanvas(false);
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        //update fill bar
        _controller.UIManager.UpdateFillAmount(StateDuration, 2f);

        if(StateDuration > 2f)
        {
            _stateMachine.ChangeState(_stateMachine.SetupState);
        }
    }
}
