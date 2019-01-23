using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPistol : Projectile
{
    void Start()
    {
        timeToLive = 0.5f;
        damage = 10;
    }
}
