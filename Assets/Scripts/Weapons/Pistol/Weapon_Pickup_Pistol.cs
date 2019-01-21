using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class Weapon_Pickup_Pistol : Weapon_Pickup
{
    // Start is called before the first frame update
    void Start()
    {
        type = (int)Weapon_Constants.weapon_types.Pistol;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
