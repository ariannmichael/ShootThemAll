using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlashBoss : Boss
{
    private static Rigidbody2D rb;
    private float SLASH_SIZE = 120f;
    private float OFFSET = 80f;
    private float positionXMax;
    private float amplitude = 0.7f;
    private float minFrequency = 0.7f;
    private float maxFrequency = 1.3f;
    private float frequency;
    private float startY;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 maxPosition = Camera.main.ViewportToWorldPoint(Vector2.one); // (1,1)
        positionXMax = maxPosition.x - (SLASH_SIZE + OFFSET)/100;

        startY = transform.position.y;
        frequency = Random.Range(minFrequency, maxFrequency);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > positionXMax)
        {
            Vector2 position = transform.position;
            position.x -= Time.deltaTime;
            transform.position = position;
        }
        
        Movement();
    }

    public override void Movement()
    {
        float yOffset = Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = new Vector2(transform.position.x, startY + yOffset);
    }

    public override void Attack()
    {
        throw new NotImplementedException();
    }

    public override void Hit(int damage)
    {
        Debug.Log(damage);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pick"))
        {
            Hit(1);
        }
    }
    
    
}
