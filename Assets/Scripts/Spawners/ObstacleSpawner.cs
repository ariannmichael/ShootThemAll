using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Obstacle obstaclePrefab;
    private float timeBtwSpawn = 0f;
    [SerializeField] private float spawnTime = 6f;

    // Update is called once per frame
    void Update()
    {
        timeBtwSpawn += Time.deltaTime;

        if (timeBtwSpawn >= spawnTime)
        {
            timeBtwSpawn = 0f;

            Vector2 maxPosition = Camera.main.ViewportToWorldPoint(Vector2.one);
            Vector2 minPosition = Camera.main.ViewportToWorldPoint(Vector2.zero);

            float positionY = Random.Range(minPosition.y + 2.5f, minPosition.y + 0.5f);
            Vector2 spawnPosition = new Vector2(maxPosition.x + 0.5f, positionY);

            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
