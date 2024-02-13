using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateMachine state_machine);
    public abstract void ExitState(PlayerStateMachine state_machine);
    public abstract void UpdateState(PlayerStateMachine state_machine);
    public abstract void FixedUpdateState(PlayerStateMachine state_machine);
}
