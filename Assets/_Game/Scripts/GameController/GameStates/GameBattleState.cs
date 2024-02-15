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

        // enable battle canvas
        _controller.UIManager.EnableBattleCanvas(true);

        //play state change SFX
        _controller.AudioSFX.PlaySoundEffect(SFXType.StateChange);
    }

    public override void Exit()
    {
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

        //update enemy move text
        _controller.UIManager.UpdateEnemyMoveText(_controller.BattleController.enemyMove);

        //play win SFX
        switch (aResult)
        {
            case AttackResult.Win:
                _controller.AudioSFX.PlaySoundEffect(SFXType.Win);
                break;
            case AttackResult.Lose:
                _controller.AudioSFX.PlaySoundEffect(SFXType.Lose);
                break;
            case AttackResult.Draw:
                _controller.AudioSFX.PlaySoundEffect(SFXType.Draw);
                break;
        }
        
        //end turn
        _endTurn = true;

    }
}
