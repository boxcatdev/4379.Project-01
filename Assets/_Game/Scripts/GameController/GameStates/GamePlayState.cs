using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("STATE: Play State");
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

        //if (StateDuration > 3f) _stateMachine.ChangeState(_stateMachine.SetupState);

        /*if (StateDuration < _controller.TapLimitDuration)
        {
            if (_controller.Input.IsTapPressed == true)
            {
                Debug.Log("You Win!");
            }
        }
        else
        {
            Debug.Log("You Lose!");
        }*/

        /*if(_controller.Input.IsTapPressed == true)
        {
            Debug.Log("You Win!");
        }
        else if(StateDuration >= _controller.TapLimitDuration)
        {
            Debug.Log("You Lose!");
        }*/
    }
}
