using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVHAttackSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float timeBtwAttack = 0f;
    private float spawnTime = 3f;
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
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0, 0, -90));
            
            isSpawned = true;
        }
    }
}
