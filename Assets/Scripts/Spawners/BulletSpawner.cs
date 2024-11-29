using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour, IObserver
{
    public GameObject bulletPrefab;
    private bool isSpawned = false;
    public TimerComponent timerComponent;

    private void OnEnable()
    {
        timerComponent.AddObserver(this);
    }

    private void OnDisable()
    {
        timerComponent.RemoveObserver(this);
    }

    public void Shoot(int spriteNumber)
    {
        if (!isSpawned)
        {
            UpdateAttack(spriteNumber);   
            isSpawned = true;
        }
    }

    public void OnNotify()
    {
        isSpawned = false;
    }

    public void UpdateAttack(int spriteNumber)
    {
        switch (spriteNumber)
        {
            case 0:
                Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                break;
            case 1:
                InstantiateBulletWithRotation(15);
                InstantiateBulletWithRotation(0);
                InstantiateBulletWithRotation(-15);
                break;
            case 2:
                timerComponent.timeDuration = 0.3f;
                Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
                break;
            case 3:
                InstantiateBiggerBullet();
                break;
        }
    }

    void InstantiateBulletWithRotation(float angle)
    {
        Quaternion rotation = bulletPrefab.transform.rotation * Quaternion.Euler(0, 0, angle);
        Instantiate(bulletPrefab, transform.position, rotation);
    }

    void InstantiateBiggerBullet()
    {
        bulletPrefab.transform.localScale = new Vector3(2.5f, 2.5f, 1f);
        Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
    }
}
