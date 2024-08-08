using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float velocityX = 2f; 
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * velocityX * -1f;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
