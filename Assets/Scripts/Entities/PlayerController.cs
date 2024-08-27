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

    // [SerializeField] private AudioSource hurtSound;

    [SerializeField] private PlayerSO _playerSo;

    private SpriteRenderer _renderer;
    public Sprite[] sprites;
    private int _spriteIndex = 0;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = _playerSo.Sprite;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            BulletSpawner.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            ChangeSkin();
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

    private void ChangeSkin()
    {
        _spriteIndex = _spriteIndex + 1 >= sprites.Length ? 0 : _spriteIndex + 1;
        _renderer.sprite = sprites[_spriteIndex];
        _playerSo.Sprite = sprites[_spriteIndex];
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
        
        // hurtSound.Play();
        _animator.SetTrigger("Hurt");
        LevelManager.instance.UpdatePlayerLife("damage");
        
        
        // StartCoroutine(StopAnimation());
    }

    // IEnumerator StopAnimation()
    // {
    //     yield return new WaitForSeconds(_invTime);
    //     _renderer.color = Color.white;
    // }
}
