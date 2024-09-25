using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour, IObserver
{
    [FormerlySerializedAs("enemyPrefab")] public Enemy skullPrefab;
    private float timeBtwSpawn = 0f;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] Subject _subject;
    public bool isSpawning { get; set; } = true;


    private void OnEnable()
    {
        _subject.AddObserver(this);
    }

    private void OnDisable() {
        _subject.RemoveObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning) return;

        timeBtwSpawn += Time.deltaTime;

        if(timeBtwSpawn >= spawnTime)
        {
            timeBtwSpawn = 0f;

            Vector2 maxPosition = Camera.main.ViewportToWorldPoint(Vector2.one); // (1,1)
            Vector2 minPosition = Camera.main.ViewportToWorldPoint(Vector2.zero); // (0,0)

            float positionY = Random.Range(minPosition.y, maxPosition.y);
            Vector2 spawnPosition = new Vector2(maxPosition.x + 0.5f, positionY);

            Instantiate(skullPrefab, spawnPosition, Quaternion.identity);
        }
    }

    public void OnNotify()
    {
        isSpawning = false;
    }
}
