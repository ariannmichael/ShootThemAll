using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneIdleState : BaseState<PlaneStateMachine.PlaneState>
{

    private float amplitude = 1f;
    private float minFrequency = 1f;
    private float maxFrequency = 2f;
    private float frequency;
    private float velocityX = -3.2f;
    private float startY;
    private float maxMagnitude = 5f;
    private float rotationSpeed = 5f; // Controls the rate of smoothing
    private float rotationVelocity = 0f; // Required by SmoothDampAngle
    
    private PlaneStateMachine planeStateMachine;
    private Transform planeTransform;
    private Rigidbody2D rb;

    
    public PlaneIdleState() : base(PlaneStateMachine.PlaneState.Idle) {}
    
    public override void EnterState(StateMachine<PlaneStateMachine.PlaneState> planeMachine)
    {
        planeStateMachine = planeMachine as PlaneStateMachine;

        if (!planeStateMachine) return;
        
        planeTransform = planeStateMachine.transform; 
        rb = planeStateMachine.rb;
        
        // velocityX = Random.Range(minVelocity, maxVelocity);
        startY = planeTransform.transform.position.y;
        frequency = Random.Range(minFrequency, maxFrequency);
    }

    public override void FixedUpdateState()
    {
        Movement();
    }

    public override PlaneStateMachine.PlaneState GetNextState()
    {
        if (ShouldSwitchToFollow())
        {
            return PlaneStateMachine.PlaneState.Follow;
        }

        return PlaneStateMachine.PlaneState.Idle;
    }
    
    void Movement()
    {
        if (Mathf.Abs(rb.rotation) > 0f)
        {
            // Smoothly adjust the rotation towards the target angle
            float smoothedAngle = Mathf.SmoothDampAngle(rb.rotation, 0, ref rotationVelocity, rotationSpeed * Time.fixedDeltaTime);
            rb.rotation = smoothedAngle;
        }
        // Float up/down with a Sin()
        var yOffset = Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
        planeTransform.position = new Vector2(planeTransform.position.x, startY + yOffset);
        
        rb.velocity = new Vector2(velocityX, 0);
    }
    
    bool ShouldSwitchToFollow()
    {
        Vector2 direction = (Vector2)planeStateMachine.player.transform.position - this.rb.position;
        
        if (direction.magnitude < maxMagnitude && direction.x < 0)
        {
            return true;
        }

        return false;
    }
    
}
