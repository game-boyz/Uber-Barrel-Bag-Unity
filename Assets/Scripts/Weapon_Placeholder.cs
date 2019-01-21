using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class Weapon_Placeholder : MonoBehaviour
{
    private int current_weapon_type;

    // This is filled with weapon prefabs in the unity inspector
    public Weapon[] possible_weapons;

    // Start is called before the first frame update
    void Start()
    {
        current_weapon_type = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SpawnWeapon(int type) {
        if (type != current_weapon_type) {
            Debug.Log($"Spawning {type}");
            current_weapon_type = type;
            Instantiate(possible_weapons[type], transform.position, transform.rotation).transform.parent = gameObject.transform;

            return true;
        }

        return false;
    }
}
