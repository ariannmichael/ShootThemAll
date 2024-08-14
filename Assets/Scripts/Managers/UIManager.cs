using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text scoreValue;

    private void Awake()
    {
        instance = this;
    }
}
