using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float velocityX = -2f;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        _rb.velocity = new Vector2(velocityX, 0);
    }
}
