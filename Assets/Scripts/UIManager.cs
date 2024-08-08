using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private UIManager _uiManager;
    public TMP_Text scoreValue;

    private void Awake()
    {
        _uiManager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
