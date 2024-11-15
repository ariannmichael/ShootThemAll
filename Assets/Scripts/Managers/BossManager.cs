using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : Subject, IObserver
{
    public Boss bossPrefab;
    [SerializeField] private TimerComponent _timerComponent;
    private bool instantiated = false;
    

    private void OnEnable()
    {
        _timerComponent.AddObserver(this);
    }

    private void OnDisable()
    {
        _timerComponent.RemoveObserver(this);
    }

    public void OnNotify()
    {
        if (!instantiated)
        {
            Vector2 maxPosition = Camera.main.ViewportToWorldPoint(Vector2.one); // (1,1)
            
            float positionY = 0.5f;
            Vector2 spawnPosition = new Vector2(maxPosition.x, positionY);

            Instantiate(bossPrefab, spawnPosition, bossPrefab.transform.rotation);
            instantiated = true;
            NotifyObservers();
        }
    }
}
