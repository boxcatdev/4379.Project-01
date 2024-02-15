using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class StateMachineMB : MonoBehaviour
{
    public State CurrentState {  get; private set; }
    private State _previousState;

    private bool _inTransition = false;

    public void ChangeState(State newState)
    {
        if(CurrentState == newState || _inTransition) return;

        ChangeStateSequence(newState);
    }

    private void ChangeStateSequence(State newState)
    {
        _inTransition = true;

        //run exit sequence first
        CurrentState?.Exit();
        StoreStateAsPrevious(newState);

        CurrentState = newState;

        //begin new enter sequence
        CurrentState?.Enter();
        _inTransition = false;
    }

    //previous state stuff
    private void StoreStateAsPrevious(State newState)
    {
        // if no previous state
        if (_previousState == null && newState != null)
            _previousState = newState;
        else if (_previousState != null && CurrentState != null)
            _previousState = CurrentState;
    }

    public void ChangeStateToPrevious()
    {
        if (_previousState != null)
            ChangeState(_previousState);
        else
            Debug.LogWarning("There is no previous state to change to!");
    }

    protected virtual void Update()
    {
        if(CurrentState != null && !_inTransition)
            CurrentState.Tick();
    }
    protected virtual void FixedUpdate()
    {
        if(CurrentState != null && !_inTransition)
            CurrentState.FixedTick();
    }
    protected virtual void OnDestroy()
    {
        CurrentState?.Exit();
    }
}
