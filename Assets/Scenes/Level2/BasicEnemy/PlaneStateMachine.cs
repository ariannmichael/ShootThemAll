using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneStateMachine : StateMachine<PlaneStateMachine.PlaneState>
{
    public enum PlaneState
    {
        Idle,
        Follow
    }
    
    
    public Rigidbody2D rb;
    private BaseState<PlaneState> currentState;


    private void Awake()
    {
        // rb = GetComponent<Rigidbody2D>();
        
        PlaneIdleState planeIdleState = new PlaneIdleState();
        PlaneFollowState planeFollowState = new PlaneFollowState();
        
        states.Add(PlaneState.Idle, planeIdleState);
        states.Add(PlaneState.Follow, planeFollowState);

        currentState = planeIdleState;
    }

    new void Start()
    {
        if (currentState == null) return;
        
        currentState.EnterState(this);
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdateState();
    }
}
