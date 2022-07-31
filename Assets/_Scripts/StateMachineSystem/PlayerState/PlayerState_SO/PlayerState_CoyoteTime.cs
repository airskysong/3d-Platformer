using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_CoyoteTime.asset", 
    menuName = "ScriptableObject/PlayerState/PlayerState_CoyoteTime")]
public class PlayerState_CoyoteTime : PlayerState
{
    [Header("土狼时间")]
    [SerializeField] [Range(0, 1)] float coyoteTime;
    public override void Enter()
    {
        base.Enter();
        player.SetGravity(false);
    }

    public override void Exit()
    {
        player.SetGravity(true);
    }

    public override void LogicUpdate()
    {
        if(durationTime >= coyoteTime)
        {
            stateMachine.SwitchStart(typeof(PlayerState_Fall));
        }
        else if (input.isJump)
        {
            stateMachine.SwitchStart(typeof(PlayerState_JumpUp));
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        player.SetHorizontalVelocity(player.MoveSpeed.x);
    }
}
