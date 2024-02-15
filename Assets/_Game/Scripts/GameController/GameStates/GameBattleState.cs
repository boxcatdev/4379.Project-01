using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBattleState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    private bool _endTurn = false;

    public GameBattleState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        //refresh state UI
        _controller.UIManager.RefreshStateText("GameBattleState");

        Debug.Log("STATE: Battle State");

        // subscribe to touch input component
        TouchInput.OnClicked += DoBattleStuff;
    }

    public override void Exit()
    {
        // unsubscribe to touch input component
        TouchInput.OnClicked -= DoBattleStuff;

        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        //if (_endTurn) _stateMachine.ChangeState(_stateMachine.SetupState);

        if (StateDuration > 2f) _stateMachine.ChangeState(_stateMachine.SetupState);
    }

    private void DoBattleStuff()
    {

    }
}
