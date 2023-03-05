using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutGameOverState : CoconutBaseState
{
    private Vector3 _defeatedRotation = new Vector3(337.537109f, 6.48022461f, 335.649231f);
    public CoconutGameOverState(CoconutStateMachine ctx, CoconutStateFactory factory, string stateName) : base(ctx, factory, stateName) { }





    public override void EnterState()
    {
        Time.timeScale = 1f;
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
        }
        else
        {
            _ctx.Shovel.parent = _ctx.transform;
            _ctx.Shovel.localPosition = new Vector3(-0.303999782f, 0.109999977f, -0.132999957f);
            _ctx.Shovel.localRotation = Quaternion.Euler(new Vector3(308.328156f, 39.0523949f, 75.0800476f));

            _ctx.CanvasController.SetWinner(_ctx.CoconutIndex+1);
            _ctx.LookAtPositioner.transform.LeanMove(_ctx.transform.position, 0.2f).setEaseInBounce();
            _ctx.ShovelController.EnableTrail();
            _ctx.Rigidbody.velocity = Vector3.zero;
        }
    }
    public override void UpdateState()
    {
        if (_ctx.Winner) _ctx.transform.Rotate(Vector3.up, 500f * Time.deltaTime);
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
