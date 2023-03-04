using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutGameOverState : CoconutBaseState
{
    private Vector3 _defeatedRotation = new Vector3(337.537109f, 6.48022461f, 335.649231f);
    public CoconutGameOverState(CoconutStateMachine ctx, CoconutStateFactory factory, string stateName) : base(ctx, factory, stateName) { }





    public override void EnterState()
    {
        _ctx.LookAtPositioner.enabled = false;
        _ctx.ShovelController.enabled = false;
        _ctx.CoconutRotator.enabled = false;
        _ctx.Shovel.GetComponent<Animator>().enabled = false;
        _ctx.CoconutMovementController.IsInBattle = false;
        _ctx.HPBar.gameObject.SetActive(false);
        _ctx.HpBarBack.gameObject.SetActive(false);

        if (!_ctx.Winner)
        {
            _ctx.Rigidbody.freezeRotation = false;
            _ctx.ShovelController.GetComponent<Rigidbody>().isKinematic = false;
            _ctx.ShovelController.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
    public override void UpdateState()
    {
        if (_ctx.Winner) _ctx.transform.Rotate(Vector3.up, 10f);
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
