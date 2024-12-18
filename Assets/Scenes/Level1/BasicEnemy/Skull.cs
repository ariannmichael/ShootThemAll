using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Skull : Enemy
{
    private Rigidbody2D rb;
    public float amplitude = 0.7f;
    public float minFrequency = 0.7f;
    public float maxFrequency = 1.3f;
    public float frequency;
    private float velocityX = -4f;
    private float startY;

    [SerializeField] private float scoreValue = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // velocityX = Random.Range(minVelocity, maxVelocity);
        startY = transform.position.y;
        frequency = Random.Range(minFrequency, maxFrequency);
    }

    private void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    protected override void Movement()
    {
        // Float up/down with a Sin()
        var yOffset = Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = new Vector2(transform.position.x, startY + yOffset);

        rb.velocity = new Vector2(velocityX, 0);        
    }

    protected override void UpdateScore()
    {
        LevelManager.instance.UpdateScore(scoreValue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pick"))
        {
            UpdateScore();
            Destroy(gameObject);
            if (this.ReturnWithProbability(dropPowerUpChance))
            {
                DropItem();
                Debug.Log("Drop power up");
            } else if (this.ReturnWithProbability(dropLifeChance))
            {
                DropItem();
                Debug.Log("Drop life");
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); 
    }
}
