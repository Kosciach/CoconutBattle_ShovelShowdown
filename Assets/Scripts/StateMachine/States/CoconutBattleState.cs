using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutBattleState : CoconutBaseState
{
    public CoconutBattleState(CoconutStateMachine ctx, CoconutStateFactory factory, string stateName) : base(ctx, factory, stateName) { }





    public override void EnterState()
    {
        _ctx.BattleSwitch = false;
        _ctx.LookAtPositioner.enabled = true;
        _ctx.ShovelController.enabled = true;
        _ctx.CoconutRotator.enabled = true;
        _ctx.Shovel.GetComponent<Animator>().enabled = true;
        _ctx.CoconutMovementController.IsInBattle = true;
        _ctx.HPBar.gameObject.SetActive(true);
        _ctx.HpBarBack.gameObject.SetActive(true);
    }
    public override void UpdateState()
    {

    }
    public override void FixedUpdateState()
    {
        _ctx.CoconutMovementController.Movement();

        _ctx.HPBar.position = _ctx.transform.position + Vector3.up * 2;
        _ctx.HpBarBack.position = _ctx.HPBar.position;
    }
    public override void CheckStateChange()
    {
        if (_ctx.IsGameOver) ChangeState(_factory.GameOver());
    }
    protected override void ExitState()
    {
        _ctx.CoconutMovementController.IsInBattle = false;
    }

}
