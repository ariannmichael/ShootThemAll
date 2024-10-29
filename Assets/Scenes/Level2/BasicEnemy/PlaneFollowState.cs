using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFollowState : BaseState<PlaneStateMachine.PlaneState>
{
    public PlaneFollowState() : base(PlaneStateMachine.PlaneState.Follow)
    {
    }

    public override void EnterState(StateMachine<PlaneStateMachine.PlaneState> plane)
    {
        // noop
    }

    public override void ExitState()
    {
        // noop
    }

    public override void UpdateState()
    {
        // noop
    }

    public override void FixedUpdateState()
    {
        // noop
    }

    public override PlaneStateMachine.PlaneState GetNextState()
    {
        // noop
        return PlaneStateMachine.PlaneState.Follow;
    }

    public override void OnTriggerEnter(Collider collider)
    {
        // noop
    }

    public override void OnTriggerStay(Collider collider)
    {
        // noop
    }

    public override void OnTriggerExit(Collider collider)
    {
        // noop
    }
}
