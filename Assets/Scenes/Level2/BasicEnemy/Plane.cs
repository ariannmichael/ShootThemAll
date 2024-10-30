using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Plane : Enemy
{
    [SerializeField] private float scoreValue = 1f;

    void Start()
    {
        
    }

    private void Update()
    {
    }

    protected override void Movement()
    {}

    protected override void UpdateScore()
    {
        LevelManager.instance.UpdateScore(scoreValue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pick") || other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); 
    }
}
