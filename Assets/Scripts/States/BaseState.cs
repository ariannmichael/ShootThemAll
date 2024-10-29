using System;
using UnityEngine;

public abstract class BaseState<EState> where EState : Enum
{
    public EState stateKey { get; private set; }

    public BaseState(EState key)
    {
        stateKey = key;
    }

    public abstract void EnterState(StateMachine<EState> plane);
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract EState GetNextState();
    public abstract void OnTriggerEnter(Collider collider);
    public abstract void OnTriggerStay(Collider collider);
    public abstract void OnTriggerExit(Collider collider);
}
