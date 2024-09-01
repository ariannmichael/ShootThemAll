using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public abstract class Enemy : MonoBehaviour
{

    public float dropLifeChance = 5f;
    public float dropPowerUpChance = 10f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        this.Movement();
    }

    protected abstract void Movement();

    protected abstract void UpdateScore();

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

    public bool ReturnWithProbability(float percentage)
    {
        Random random = new Random();
        int randomNumber = random.Next(0, 100);
        return randomNumber < (percentage / 100);
    }

    public void DropItem()
    {
        
    }
}
