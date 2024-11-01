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

    public Image[] hearts;

    private void Awake()
    {
        instance = this;
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
