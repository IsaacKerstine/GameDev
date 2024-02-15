using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerBaseState
{
    public float max_speed = 6f;
    public float acceleration = 60f;
    public float stop_speed = 0.5f;
    public float jump_impulse = 10f;
    public float friction = 4f;


    public override void EnterState(PlayerStateMachine state_machine)
    {

    }
    public override void ExitState(PlayerStateMachine state_machine)
    {
        
    }
    public override void UpdateState(PlayerStateMachine state_machine)
    {
        
    }
    public override void FixedUpdateState(PlayerStateMachine state_machine)
    {
        state_machine.player_velocity = MoveGround(state_machine.wish_dir, state_machine.player_velocity);
        
        if (!state_machine.character_controller.isGrounded)
        {
            state_machine.SwitchState(this, state_machine.air_state);
        }
        if (state_machine.jump_button_pressed)
        {
            state_machine.player_velocity.y = jump_impulse;
            state_machine.SwitchState(this, state_machine.air_state);
        }
    }

    private Vector3 MoveGround(Vector3 wish_dir, Vector3 current_velocity)
    {
        Vector3 new_velocity = new Vector3(current_velocity.x, 0, current_velocity.z);

        float speed = new_velocity.magnitude;
        if (speed <= stop_speed)
        {
            new_velocity = Vector3.zero;
            speed = 0;
        }

        if (speed != 0)
        {
            float drop = speed * friction * Time.deltaTime;
            new_velocity *= Mathf.Max(speed - drop, 0) / speed;
        }
        new_velocity = new Vector3(new_velocity.x, current_velocity.y, new_velocity.z);

        return Accelerate(wish_dir, new_velocity, acceleration, max_speed);
    }
}
