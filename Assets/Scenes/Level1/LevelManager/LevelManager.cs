using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public SlashBoss slashPrefab;
    private float timer = 0f;
    [SerializeField] private float spawnTime = 0.5f;
    private bool instanciated = false;
    private int playerLife = 3;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime && !instanciated)
        {
            Vector2 maxPosition = Camera.main.ViewportToWorldPoint(Vector2.one); // (1,1)
            
            float positionY = 0.5f;
            Vector2 spawnPosition = new Vector2(maxPosition.x, positionY);

            Instantiate(slashPrefab, spawnPosition, Quaternion.identity);
            instanciated = true;
        }
    }

    public void UpdatePlayerLife(int damage)
    {
        playerLife -= damage;
    }
}
