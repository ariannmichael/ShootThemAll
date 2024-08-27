using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    
    private float spriteOffsetX = 0.8f;
    private float spriteOffsetY = 0.5f;
    
    public BulletSpawner BulletSpawner;
    
    private Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            BulletSpawner.Shoot();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        CheckLimitPosition();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

       Vector3 movement = new Vector3(horizontal, vertical, 0);
       transform.position += movement * speed * Time.deltaTime; 
    }  

    void CheckLimitPosition()
    {
        Vector2 maxPosition = Camera.main.ViewportToWorldPoint(Vector2.one); // (1,1)
        Vector2 minPosition = Camera.main.ViewportToWorldPoint(Vector2.zero); // (0,0)

        Vector2 position = transform.position;

        position.x = Mathf.Clamp(position.x, minPosition.x + spriteOffsetX, maxPosition.x - spriteOffsetX);
        position.y = Mathf.Clamp(position.y, minPosition.y + spriteOffsetY, maxPosition.y - spriteOffsetY);

        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Pick"))
        {
            Damage();
        }
    }

    private void Damage()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
        {
            return;
        }
        
        _animator.SetTrigger("Hurt");
        // StartCoroutine(StopAnimation());
        LevelManager.instance.UpdatePlayerLife("damage");
    }

    // IEnumerator StopAnimation()
    // {
    //     yield return new WaitForSeconds(_invTime);
    //     _renderer.color = Color.white;
    // }
}
