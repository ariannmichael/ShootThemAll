using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneIdleState : BaseState<PlaneStateMachine.PlaneState>
{

    public float amplitude = 2f;
    public float minFrequency = 1f;
    public float maxFrequency = 3f;
    public float frequency;
    private float velocityX = -2f;
    private float startY;
    
    private Transform planeTransform;
    private Rigidbody2D rb;
    
    public PlaneIdleState() : base(PlaneStateMachine.PlaneState.Idle) {}
    
    public override void EnterState(StateMachine<PlaneStateMachine.PlaneState> plane)
    {
        PlaneStateMachine planeStateMachine = plane as PlaneStateMachine;
        
        planeTransform = planeStateMachine.transform; 
        rb = planeStateMachine.rb;
        
        // velocityX = Random.Range(minVelocity, maxVelocity);
        startY = planeTransform.transform.position.y;
        frequency = Random.Range(minFrequency, maxFrequency);
    }

    public override void ExitState()
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        throw new System.NotImplementedException();
    }

    public override void FixedUpdateState()
    {
        Movement();
    }

    public override PlaneStateMachine.PlaneState GetNextState()
    {
        return PlaneStateMachine.PlaneState.Idle;
    }

    public override void OnTriggerEnter(Collider collider)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider collider)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider collider)
    {
        throw new System.NotImplementedException();
    }
    
    void Movement()
    {
        // Float up/down with a Sin()
        var yOffset = Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
        planeTransform.position = new Vector2(planeTransform.position.x, startY + yOffset);
        
        rb.velocity = new Vector2(velocityX, 0);
    }
    
}
