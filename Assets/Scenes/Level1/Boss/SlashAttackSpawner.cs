using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttackSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float timeBtwAttack = 0f;
    private float spawnTime = 5f;
    private bool isSpawned = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeBtwAttack += Time.deltaTime;

        if(timeBtwAttack >= spawnTime)
        {
            isSpawned = false;
            timeBtwAttack = 0;
        }
    }

    public void Shoot()
    {
        if(!isSpawned)
        {
            InstantiateBulletWithRotation(15);
            InstantiateBulletWithRotation(0);
            InstantiateBulletWithRotation(-15);
            
            isSpawned = true;
        }
    }

    void InstantiateBulletWithRotation(float angle)
    {
        Quaternion rotation = bulletPrefab.transform.rotation * Quaternion.Euler(0, 0, angle);
        Instantiate(bulletPrefab, transform.position, rotation);
    }
}
