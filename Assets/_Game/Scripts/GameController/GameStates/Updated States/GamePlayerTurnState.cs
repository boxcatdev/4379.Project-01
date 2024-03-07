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

        //enable player turn controller
        _controller.PlayerTurn.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();

        //disable player turn controller
        _controller.PlayerTurn.gameObject.SetActive(false);
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
