using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private FloatSO scoreSO;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIManager.instance.scoreValue.text = scoreSO.Value + "";
    }

    public void UpdateScore(float value)
    {
        scoreSO.Value += value;
        UIManager.instance.scoreValue.text = scoreSO.Value + "";
    }

    public void UpdatePlayerLife(string type)
    {
        if (type == "damage")
        {
            Health.instance.Decrease();
        }
        else
        {
            Health.instance.Increase();
        }
    }
}
