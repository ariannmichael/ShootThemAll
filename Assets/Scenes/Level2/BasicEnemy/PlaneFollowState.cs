using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlaneFollowState : BaseState<PlaneStateMachine.PlaneState>
{
    private PlaneStateMachine planeStateMachine;
    private Transform planeTransform;
    private Rigidbody2D rb;
    private bool hasToSwitch = false;
    private float moveSpeed = 3.6f;
    private float maxMagnitude = 2f;
    private float switchMagnitude = 5f;
    private float velocityX = -3f;
    
    public PlaneFollowState() : base(PlaneStateMachine.PlaneState.Follow)
    {
    }

    public override void EnterState(StateMachine<PlaneStateMachine.PlaneState> planeMachine)
    {
        planeStateMachine = planeMachine as PlaneStateMachine;

        if (!planeStateMachine) return;

        planeTransform = planeStateMachine.transform;
        rb = planeStateMachine.rb;
    }

    public override void FixedUpdateState()
    {
        Vector2 direction = (Vector2)planeStateMachine.player.transform.position - rb.position;

        if (direction.magnitude > maxMagnitude && direction.x < 0)
        {
            rb.velocity = direction.normalized * moveSpeed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180f;
            rb.rotation = angle;
        }
        else
        {
            rb.velocity = new Vector2(velocityX, 0);
        }


        if (direction.magnitude > switchMagnitude)
        {
            // InitiateSwitchAfterDelay(delayTime);
            hasToSwitch = true;
        }
    }

    private async void InitiateSwitchAfterDelay(int delaySeconds)
    {
        await Task.Delay(delaySeconds);
        hasToSwitch = true;
    }

    public override PlaneStateMachine.PlaneState GetNextState()
    {
        if (hasToSwitch)
        {
            return PlaneStateMachine.PlaneState.Idle;
        }

        return PlaneStateMachine.PlaneState.Follow;
    }
}

