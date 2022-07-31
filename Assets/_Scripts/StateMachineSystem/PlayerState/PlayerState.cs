using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected Animator animator;
    protected PlayerStateMachine stateMachine;
    protected PlayerController player;
    protected PlayerInput input;
    protected Dictionary<System.Type, IState> stateTable;

    [Header("播放的动画名字")]
    public string animationClipName;
    [Header("过渡时间")]
    [Range(0, 1)] public float durationPercent;
    protected int stateHashName;

    protected float durationTime => Time.time - startTime;

    protected float startTime;

    protected bool IsAnimationFinished => durationTime >= animator.GetCurrentAnimatorStateInfo(0).length;

    protected Vector2 currentSpeed;

    public void Initialize(Animator animator, PlayerStateMachine stateMachine, PlayerController controller,
        PlayerInput input, Dictionary<System.Type, IState> stateTable)
    {
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.player = controller;
        this.input = input;
        this.stateTable = stateTable;

        this.stateHashName = Animator.StringToHash(animationClipName);
    }
    public virtual void Enter()
    {
        currentSpeed = player.MoveSpeed;
        animator.CrossFade(stateHashName, durationPercent);
        startTime = Time.time;
    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate()
    {
        if (input.move.x < 0)
            player.FlipX();
        else if (input.move.x > 0)
            player.NoFlipX();
    }

}
