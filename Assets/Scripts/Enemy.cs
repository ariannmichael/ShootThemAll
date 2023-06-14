using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float minVelocity = 1f;
    public float maxVelocity = 2f;
    private float velocityX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocityX = Random.Range(minVelocity, maxVelocity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(-velocityX, 0);
    }

    public void DestroyEnemy(bool laser)
    {
        if(laser)
        {
            // Score.ScorePoints += 1;
        }
        Destroy(gameObject);
    }
}
