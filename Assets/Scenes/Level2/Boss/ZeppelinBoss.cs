using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class ZeppelinBoss : Boss
{
    private static Rigidbody2D rb;
    private float ZEPPELIN_SIZE = 140f;
    private float OFFSET = 100f;
    private float positionXMax;

    private float amplitude = 1.6f;
    private float minFrequency = 0.8f;
    private float maxFrequency = 1f;
    private float frequency;
    private float startY;

    public ZeppelinAttackSpawner zAttackSpawner;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        Vector2 maxPosition = Camera.main.ViewportToWorldPoint(Vector2.one);
        positionXMax = maxPosition.x - (ZEPPELIN_SIZE + OFFSET) / 100;

        startY = transform.position.y;
        frequency = Random.Range(minFrequency, maxFrequency);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > positionXMax)
        {
            Vector2 position = transform.position;
            position.x -= Time.deltaTime;
            transform.position = position;
        }
        
        Movement();
        Attack();
    }

    public override void Movement()
    {
        float yOffset = Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = new Vector2(transform.position.x, startY + yOffset);
    }

    public override void Attack()
    {
        zAttackSpawner.Shoot();
    }

    public override void Hit(int damage)
    {
        health -= damage;

        _animator.SetTrigger("Hurt");

        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Level3");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pick"))
        {
            Hit(1);
        }
    }
}
