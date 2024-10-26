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

    public void Shoot()
    {
        if (!isSpawned)
        {
            Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);
            isSpawned = true;
        }
    }

    public void OnNotify()
    {
        isSpawned = false;
    }
}
