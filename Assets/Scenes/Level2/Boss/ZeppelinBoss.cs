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

    private float timeBtwSpecialAttack = 0f;
    [SerializeField] private float specialAttackTime = 20f;
    private bool isSpecialAttack = true;
    
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

        timeBtwSpecialAttack += Time.deltaTime;

        if(timeBtwSpecialAttack >= specialAttackTime)
        {
            isSpecialAttack = false;
            _animator.SetTrigger("Special");
            timeBtwSpecialAttack = 0;
        }
        
        Movement();
        Attack();
        SpecialAttack();
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

    public void SpecialAttack()
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Special") && stateInfo.normalizedTime < 1)
        {
            return;
        }

        float specialAttackVelocity = 5f;
        // Go fast to the most left side of the screen then come back to the right side that it was before but slowly
        if (!isSpecialAttack)
        {
            if (transform.position.x > -positionXMax)
            {
                Vector2 position = transform.position;
                position.x -= Time.deltaTime * specialAttackVelocity;
                transform.position = position;
            }
            else
            {
                isSpecialAttack = true;
            }
        }
        else
        {
            if (transform.position.x < positionXMax)
            {
                Vector2 position = transform.position;
                position.x += Time.deltaTime * specialAttackVelocity / 2;
                transform.position = position;
            }
        }

    }

    public void UpdateScore()
    {
        LevelManager.instance.UpdateScore(2000);
    }

    public override void Hit(int damage)
    {
        health -= damage;

        _animator.SetTrigger("Hurt");

        if (health <= 0)
        {
            UpdateScore();
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
