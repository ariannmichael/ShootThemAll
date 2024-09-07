using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : BossBullet
{
    public GameObject childSpriteObject;
    
    // Update is called once per frame
    void Update()
    {
        this.rb.velocity = transform.up * this.velocityX * -1f;
        Rotate();
    }

    void Rotate()
    {
        childSpriteObject.transform.Rotate(0, 0, 500 * Time.deltaTime);
    }
}
