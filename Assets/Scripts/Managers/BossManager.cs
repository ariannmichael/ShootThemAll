using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : Subject
{
    public Boss bossPrefab;
    private float timer = 0f;
    [SerializeField] public float spawnTime = 100.0f;
    private bool instantiated = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime && !instantiated)
        {
            Vector2 maxPosition = Camera.main.ViewportToWorldPoint(Vector2.one); // (1,1)
            
            float positionY = 0.5f;
            Vector2 spawnPosition = new Vector2(maxPosition.x, positionY);

            Instantiate(bossPrefab, spawnPosition, Quaternion.identity);
            instantiated = true;
            NotifyObservers();
        }
    }
}
