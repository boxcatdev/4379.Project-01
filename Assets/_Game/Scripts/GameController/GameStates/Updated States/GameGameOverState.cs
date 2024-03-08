using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGameOverState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameGameOverState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        //refresh state UI
        _controller.UIManager.RefreshStateText("GameOverState");

        //update instruction UI
        _controller.UIManager.UpdateInstructionText(StatesUIEnum.GameOver);
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
    }
}
