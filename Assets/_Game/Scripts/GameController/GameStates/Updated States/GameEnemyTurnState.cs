using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnemyTurnState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

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
        _controller.UIManager.UpdateInstructionText(StatesUIEnum.Enemy);

        //enable enemy turn controller
        _controller.EnemyTurn.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();

        //disable enemy turn controller
        _controller.EnemyTurn.gameObject.SetActive(false);
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
