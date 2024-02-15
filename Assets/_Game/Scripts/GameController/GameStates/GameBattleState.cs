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
        _endTurn = false;

        base.Enter();

        //update fill bar
        _controller.UIManager.UpdateFillAmount(StateDuration, 1f);

        //refresh state UI
        _controller.UIManager.RefreshStateText("GameBattleState");

        Debug.Log("STATE: Battle State");

        // subscribe to touch input component
        TouchInput.OnClicked += DoBattleStuff;

        // enable battle canvas
        _controller.UIManager.EnableBattleCanvas(true);
    }

    public override void Exit()
    {
        // unsubscribe to touch input component
        TouchInput.OnClicked -= DoBattleStuff;

        base.Exit();

        // disable battle canvas
        _controller.UIManager.EnableBattleCanvas(false);
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();

        if (_endTurn)
        {
            //do
            _stateMachine.ChangeState(_stateMachine.WinState);
        }

        //if (StateDuration > 2f) _stateMachine.ChangeState(_stateMachine.SetupState);
    }
    public void DoBattleStuff()
    {
        //do battle
        AttackResult aResult = _controller.BattleController.TryPlayerBattle();

        //update text in win menu
        _controller.UIManager.UpdateWinText(aResult);

        //end turn
        _endTurn = true;

    }
}
