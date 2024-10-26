using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerComponent : Subject
{
    public float timeDuration = 1f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeDuration)
        {
            NotifyObservers();
            timer = 0;
        }
    }
}
