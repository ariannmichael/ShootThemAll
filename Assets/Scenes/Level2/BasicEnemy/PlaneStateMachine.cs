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
    public GameObject player;


    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        
        PlaneIdleState planeIdleState = new PlaneIdleState();
        PlaneFollowState planeFollowState = new PlaneFollowState();
        
        states[PlaneState.Idle] = planeIdleState;
        states[PlaneState.Follow] = planeFollowState;
        currentState = states[PlaneState.Idle];
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
