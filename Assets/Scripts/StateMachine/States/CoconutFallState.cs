using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutFallState : CoconutBaseState
{
    public CoconutFallState(CoconutStateMachine ctx, CoconutStateFactory factory, string stateName) : base(ctx, factory, stateName) { }





    public override void EnterState()
    {
        _ctx.Rigidbody.isKinematic = false;
        _ctx.FallSwitch = false;
    }
    public override void UpdateState()
    {

    }
    public override void FixedUpdateState()
    {

    }
    public override void CheckStateChange()
    {
        if (_ctx.CoconutMovementController.IsGrounded) ChangeState(_factory.RotationState());
    }
    protected override void ExitState()
    {

    }

}
