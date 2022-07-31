using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Iddle.asset", menuName = "ScriptableObject/PlayerState/PlayerState_Iddle")]
public class PlayerState_Iddle : PlayerState
{
    [Header("减速度")]
    [Range(0, 10)] public float Deacceleration;

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {

    }

    public override void LogicUpdate()
    {
        if (input.move.x != 0)
        {
            stateMachine.SwitchStart(typeof(PlayerState_Run));
        }
        else if (input.isJump)
        {
            stateMachine.SwitchStart(typeof(PlayerState_JumpUp));
        }
        else if (!player.isGround())
        {
            stateMachine.SwitchStart(typeof(PlayerState_Fall));
        }
    }

    public override void PhysicUpdate()
    {
        if (currentSpeed.x != 0)
        {
            currentSpeed.x = Mathf.MoveTowards(currentSpeed.x, 0, Deacceleration * Time.fixedDeltaTime);
            player.SetHorizontalVelocity(currentSpeed.x);
        }
    }
}
