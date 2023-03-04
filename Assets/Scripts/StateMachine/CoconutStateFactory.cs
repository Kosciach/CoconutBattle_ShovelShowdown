using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutStateFactory
{
    private CoconutStateMachine _ctx;

    public CoconutStateFactory(CoconutStateMachine ctx)
    {
        _ctx = ctx;
    }


    public CoconutBaseState BattleState()
    {
        return new CoconutBattleState(_ctx, this, "Battle");
    }
    public CoconutBaseState PalmState()
    {
        return new CoconutPalmState(_ctx, this, "Palm");
    }
    public CoconutBaseState FallState()
    {
        return new CoconutFallState(_ctx, this, "Fall");
    }
    public CoconutBaseState RotationState()
    {
        return new CoconutRotateState(_ctx, this, "Rotation");
    }
    public CoconutBaseState GameOver()
    {
        return new CoconutGameOverState(_ctx, this, "GameOver");
    }
}
