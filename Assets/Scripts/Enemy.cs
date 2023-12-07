using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float amplitude = 0.7f;
    public float minFrequency = 0.7f;
    public float maxFrequency = 1.3f;
    public float frequency;
    [SerializeField]private float velocityX = -2f;
    private float startY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // velocityX = Random.Range(minVelocity, maxVelocity);
        startY = transform.position.y;
        frequency = Random.Range(minFrequency, maxFrequency);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Float up/down with a Sin()
        var yOffset = Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = new Vector2(transform.position.x, startY + yOffset);

        rb.velocity = new Vector2(velocityX, 0);
    }


    public void DestroyEnemy(bool laser)
    {
        if(laser)
        {
            // Score.ScorePoints += 1;
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); 
    }
}
