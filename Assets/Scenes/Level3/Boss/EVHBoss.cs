using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EVHBoss : Boss
{
    private static Rigidbody2D rb;
    private float EVH_SIZE = 140f;
    private float OFFSET = 100f;
    private float positionXMax;

    private float amplitude = 2f;
    private float minFrequency = 1f;
    private float maxFrequency = 1.4f;
    private float frequency;
    private float startY;

    public EVHAttackSpawner zAttackSpawner;
    private Animator _animator;

    private float timeSpecial = 0f;
    [SerializeField] private float specialTime = 1f;

    private float timeBtwSpecialAttack = 0f;
    [SerializeField] private float specialAttackTime = 1f;
    private bool isSpecialAttack = true;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        Vector2 maxPosition = Camera.main.ViewportToWorldPoint(Vector2.one);
        positionXMax = maxPosition.x - (EVH_SIZE + OFFSET) / 100;

        startY = transform.position.y;
        frequency = Random.Range(minFrequency, maxFrequency);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > positionXMax)
        {
            Vector2 position = transform.position;
            position.x -= Time.deltaTime * 2f;
            transform.position = position;
        }

        timeSpecial += Time.deltaTime;
        if (timeSpecial >= specialTime) {
            timeBtwSpecialAttack += Time.deltaTime;

            if (timeBtwSpecialAttack >= specialAttackTime)
            {
                isSpecialAttack = false;
                _animator.SetTrigger("Special");
                timeBtwSpecialAttack = 0;
            }
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

        if (!isSpecialAttack)
        {
            if (transform.position.x > -positionXMax / 3)
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
        LevelManager.instance.UpdateScore(5000);
        PlayerPrefs.SetInt("Finished", 1);
    }

    public override void Hit(int damage)
    {
        health -= damage;

        _animator.SetTrigger("Hurt");

        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
