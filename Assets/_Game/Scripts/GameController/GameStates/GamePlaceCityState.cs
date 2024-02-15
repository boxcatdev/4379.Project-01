using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlaceCityState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlaceCityState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        //refresh state UI
        _controller.UIManager.RefreshStateText("GamePlaceCityState");

        Debug.Log("STATE: Place Player & Enemy Cities");

        //place player city
        _controller.GridModify.PlaceRandomCity(true);

        //place enemy city
        _controller.GridModify.PlaceRandomCity(false);
        _controller.BattleController.StoreEnemyMove();

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
            _stateMachine.ChangeState(_stateMachine.BattleState);
    }
}
