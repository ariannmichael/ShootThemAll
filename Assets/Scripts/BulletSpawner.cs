using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float timeBtwSpawn = 0f;
    private bool isSpawned = false;
    public float spawnTime = 1f;

    private void Update()
    {
        timeBtwSpawn += Time.deltaTime;

        if (timeBtwSpawn >= spawnTime)
        {
            isSpawned = false;
            timeBtwSpawn = 0;
        }
    }

    public void Shoot()
    {
        if (!isSpawned)
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            isSpawned = true;
        }
    }
}
