using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_JumpUp.asset", menuName = "ScriptableObject/PlayerState/PlayerState_JumpUp")]
public class PlayerState_JumpUp : PlayerState
{
    [Header("跳跃")]
    public float jump;
    [Header("空中移动速度")]
    public float moveSpeed;
    [Header("加速度")]
    [Range(0, 10)] public float acceleration;
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
