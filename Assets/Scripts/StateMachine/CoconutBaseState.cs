using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoconutBaseState
{
    protected CoconutStateMachine _ctx;
    protected CoconutStateFactory _factory;

    protected CoconutBaseState(CoconutStateMachine ctx, CoconutStateFactory factory, string stateName)
    {
        _ctx = ctx;
        _factory = factory;
        _ctx.CurrentStateName = stateName;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void CheckStateChange();
    protected abstract void ExitState();


    public void ChangeState(CoconutBaseState newState)
    {
        ExitState();
        _ctx.CurrentState = newState;
        _ctx.CurrentState.EnterState();
    }

}
