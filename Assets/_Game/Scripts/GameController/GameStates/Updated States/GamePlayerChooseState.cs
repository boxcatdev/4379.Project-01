using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayerChooseState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlayerChooseState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        //refresh state UI
        _controller.UIManager.RefreshStateText("PlayerChooseState");

        //enable manager
        _controller.ChooseManager.gameObject.SetActive(true);

        //reset choices
        ChooseManager.ChosenCitiesCount = 0;

        //reset player cities
        _controller.ChooseManager.SetupEnemyDefendMoves();

        //setup enemy city defend moves

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
