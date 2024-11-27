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

    // [SerializeField] private AudioSource hurtSound;

    [SerializeField] private PlayerSO _playerSo;

    private SpriteRenderer _renderer;

    private AttackStrategy _attackStrategy;
    [SerializeField] private PlayerMovement _playerMovement;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = _playerSo.Sprite;
        _attackStrategy = new AttackStrategy();
        _attackStrategy.SetStrategy(new BasicAttack());
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _attackStrategy.Shoot();
            BulletSpawner.Shoot();
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

    public void UpdateAttack(string pedal)
    {
        switch (pedal)
        {
            case "DS1":
                _attackStrategy.SetStrategy(new AttackBigger());
                break;
            case "OD1":
                _attackStrategy.SetStrategy(new AttackDouble());
                break;
            case "TS9":
                _attackStrategy.SetStrategy(new AttackSpeed());
                break;
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
