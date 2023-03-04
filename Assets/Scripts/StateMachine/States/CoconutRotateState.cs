using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutRotateState : CoconutBaseState
{
    public CoconutRotateState(CoconutStateMachine ctx, CoconutStateFactory factory, string stateName) : base(ctx, factory, stateName) { }





    public override void EnterState()
    {
        LeanTween.rotate(_ctx.gameObject, _ctx.RotationTarget, 0.5f).setOnComplete(() =>
        {
            _ctx.Shovel.parent = _ctx.transform;
            _ctx.BattleSwitch = true;
        });
    }
    public override void UpdateState()
    {

    }
    public override void FixedUpdateState()
    {

    }
    public override void CheckStateChange()
    {
        if (_ctx.BattleSwitch) ChangeState(_factory.BattleState());
    }
    protected override void ExitState()
    {

    }

}
