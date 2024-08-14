using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if (numOfHearts >= 0)
        {
            hearts[numOfHearts - 1].enabled = false;
            numOfHearts -= 1;
        }
        else
        {
            // GameOver Man
        }
    }

    public void Increase()
    {
        hearts[numOfHearts - 1].enabled = true;
        numOfHearts += 1;
    }
}
