using System;
using System.Collections;
using System.Collections.Generic;
using Entities.Attack;
using Strategies;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public BulletSpawner BulletSpawner;
    
    private Animator _animator;

    [SerializeField] private PlayerSO _playerSo;

    private SpriteRenderer _renderer;

    [SerializeField] private PlayerMovement _playerMovement;

    private Dictionary<String, int> _playerSkins = new Dictionary<string, int>
    {
        {"Sg", 0},
        {"Les Paul", 1},
        {"FlyingV", 2},
        {"EVH", 3}
    };

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
            BulletSpawner.Shoot(_playerSkins[_playerSo.Sprite.name]);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _playerMovement.Movement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Pick") && !other.gameObject.CompareTag("PowerUp"))
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
        LevelManager.instance.UpdatePlayerLife("damage");
    }
}
