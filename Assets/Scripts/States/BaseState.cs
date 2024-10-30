using System;
using UnityEngine;

public abstract class BaseState<EState> where EState : Enum
{
    public EState stateKey { get; private set; }

    public BaseState(EState key)
    {
        stateKey = key;
    }

    public virtual void EnterState(StateMachine<EState> plane) {}

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
    }

    public virtual void FixedUpdateState()
    {
    }

    public abstract EState GetNextState();

    public virtual void OnTriggerEnter(Collider collider)
    {
    }

    public virtual void OnTriggerStay(Collider collider)
    {
    }

    public virtual void OnTriggerExit(Collider collider)
    {
    }
}
