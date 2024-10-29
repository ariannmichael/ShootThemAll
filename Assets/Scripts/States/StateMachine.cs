using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> states = new ();
    private BaseState<EState> currentState;

    public void Start()
    {
        if (currentState != null)
        {
            currentState.EnterState(this);
        }
    }

    public void Update()
    {
        if (currentState == null) return;
        
        EState nextStateKey = currentState.GetNextState();

        if (nextStateKey.Equals(currentState.stateKey))
        {
            currentState.UpdateState();
        }
        else
        {
            TransitionToState(nextStateKey);
        }
    }

    public void TransitionToState(EState stateKey)
    {
        BaseState<EState> state = states[stateKey];
        if (state == null)
            return;
        
        currentState.ExitState();
        currentState = states[stateKey];
        currentState.EnterState(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    public void OnTriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }

    public void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }
}
