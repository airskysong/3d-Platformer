using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_AirJump.asset", menuName = "ScriptableObject/PlayerState/PlayerState_AirJump")]
public class PlayerState_AirJump : PlayerState
{
    [Header("跳跃")]
    public float jump;
    [Header("空中移动速度")]
    public float moveSpeed;

    public override void Enter()
    {
        base.Enter();
        player.SetVerticalVelocity(jump);
    }

    public override void Exit()
    {
    }

    public override void LogicUpdate()
    {
        if (player.isGround())
        {
            stateMachine.SwitchStart(typeof(PlayerState_Iddle));
        }
        else if (!input.isJump || player.MoveSpeed.y < 0)
        {
            stateMachine.SwitchStart(typeof(PlayerState_Fall));
        }

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        player.SetHorizontalVelocity(moveSpeed * input.move.x);
    }
}
