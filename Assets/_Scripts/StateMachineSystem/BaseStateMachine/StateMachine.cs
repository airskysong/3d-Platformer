using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    protected IState currentState;
    protected Dictionary<System.Type, IState> stateTable;
    protected void SwitchOn(IState state)
    {
        currentState = state;
        currentState.Enter();
    }

    public void SwitchStart(IState state)
    {
        currentState.Exit();
        SwitchOn(state);
    }

    public void SwitchStart(System.Type type)
    {
        IState state;
        if (stateTable.TryGetValue(type, out state))
        {
            SwitchStart(state);
        }
    }
}
