using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Pistol : Projectile
{
    void Start()
    {
        timeToLive = 0.5f;
        damage = 10;
    }
}
