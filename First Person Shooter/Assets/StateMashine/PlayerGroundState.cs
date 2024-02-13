using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{
    public override void EnterState(PlayerStateMachine state_machine)
    {

    }
    public override void ExitState(PlayerStateMachine state_machine)
    {
        
    }
    public override void UpdateState(PlayerStateMachine state_machine)
    {
        state_machine.SwitchState(this, state_machine.air_state);
    }
    public override void FixedUpdateState(PlayerStateMachine state_machine)
    {
        
    }
}
