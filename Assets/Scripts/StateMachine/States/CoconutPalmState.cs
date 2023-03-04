using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutPalmState : CoconutBaseState
{
    public CoconutPalmState(CoconutStateMachine ctx, CoconutStateFactory factory, string stateName) : base(ctx, factory, stateName) { }





    public override void EnterState()
    {
        _ctx.transform.position = _ctx.CoconutPalmPosition;
        _ctx.transform.rotation = Quaternion.Euler(_ctx.CoconutPalmRotation);
    }
    public override void UpdateState()
    {

    }
    public override void FixedUpdateState()
    {

    }
    public override void CheckStateChange()
    {
        if (_ctx.FallSwitch) ChangeState(_factory.FallState());
    }
    protected override void ExitState()
    {

    }
}
