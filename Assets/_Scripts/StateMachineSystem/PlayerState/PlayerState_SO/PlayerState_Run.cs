using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Run.asset", menuName = "ScriptableObject/PlayerState/PlayerState_Run")]
public class PlayerState_Run : PlayerState
{
    [Header("移动速度")]
    public float moveSpeed;
    [Header("加速度")]
    [Range(0, 10)] public float acceleration;

    float lastDirect;
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {

    }

    public override void LogicUpdate()
    {
        if (input.move.x == 0)
        {
            stateMachine.SwitchStart(typeof(PlayerState_Iddle));
        }
        else if (input.isJump)
        {
            stateMachine.SwitchStart(typeof(PlayerState_JumpUp));
        }
        else if (!player.isGround())
        {
            stateMachine.SwitchStart(typeof(PlayerState_CoyoteTime));
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        if(input.move.x == -lastDirect)
        {
            currentSpeed.x = 0;
        }
        //一定要确定最终的移动方向，input.move.x确定左右方向
        currentSpeed.x = Mathf.MoveTowards(currentSpeed.x, moveSpeed * input.move.x, 
            acceleration * Time.fixedDeltaTime);
        player.SetHorizontalVelocity(currentSpeed.x);
        lastDirect = input.move.x;
    }
}
