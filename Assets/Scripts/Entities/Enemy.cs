using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

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
}
