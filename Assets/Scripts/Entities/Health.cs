using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Health instance;
    public int health;
    public int numOfHearts;

    [SerializeField] private PlayerSO _playerSo;

    public Image[] hearts;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = _playerSo.Health;
        numOfHearts = _playerSo.Health;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void Update()
    {
        
    }

    public void Decrease()
    {
        if (numOfHearts > 1)
        {
            hearts[numOfHearts - 1].enabled = false;
            numOfHearts -= 1;
            _playerSo.Health = numOfHearts;
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Increase()
    {
        hearts[numOfHearts - 1].enabled = true;
        numOfHearts += 1;
    }
}
