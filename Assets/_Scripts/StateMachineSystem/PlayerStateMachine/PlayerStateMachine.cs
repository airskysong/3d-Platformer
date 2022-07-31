using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [Header("所有玩家的状态子类")]
    [SerializeField] private PlayerState[] playerStates;

     Animator animator;
     PlayerController player;
     PlayerInput input;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        player = GetComponent<PlayerController>();
        input = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        stateTable = new Dictionary<System.Type, IState>(playerStates.Length);
        foreach(var item in playerStates)
        {
            item.Initialize(animator, this, player, input, stateTable);

            if (!stateTable.ContainsKey(item.GetType()))
            {
                stateTable.Add(item.GetType(), item);
            }
        }
        SwitchOn(stateTable[typeof(PlayerState_Iddle)]);
    }

    private void FixedUpdate()
    {
        currentState.LogicUpdate();
        currentState.PhysicUpdate();
    }
}
