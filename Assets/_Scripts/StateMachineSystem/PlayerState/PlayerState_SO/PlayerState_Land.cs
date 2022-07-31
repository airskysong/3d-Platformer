using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState_Land.asset", menuName = "ScriptableObject/PlayerState/PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    [Header("落地持续时间")]
    [SerializeField] [Range(0, 1)] float landDuration;
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {

    }

    public override void LogicUpdate()
    {
        if (input.isJump)
        {
            stateMachine.SwitchStart(typeof(PlayerState_JumpUp));
        }
        else if (durationTime > landDuration)
        {
            if (input.move.x != 0)
            {
                stateMachine.SwitchStart(typeof(PlayerState_Run));
            }
            else
            {
                stateMachine.SwitchStart(typeof(PlayerState_Iddle));
            }
        }
    }

    public override void PhysicUpdate()
    {
        player.SetHorizontalVelocity(0);
    }
}
