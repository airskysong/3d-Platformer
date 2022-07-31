using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Fall.asset", menuName = "ScriptableObject/PlayerState/PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{
    [Header("空中移动速度")]
    public float moveSpeed;
    [Header("曲线")]
    public AnimationCurve curve;
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
        if (player.isGround())
        {
            stateMachine.SwitchStart(typeof(PlayerState_Land));
        }
        else if (player.CanAirJump && input.isJump)
        {
            player.CanAirJump = false;
            stateMachine.SwitchStart(typeof(PlayerState_AirJump));
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        player.SetVerticalVelocity(curve.Evaluate(durationTime));
        player.SetHorizontalVelocity(moveSpeed * input.move.x);

    }
}
