using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class WeaponPlaceholder : MonoBehaviour
{
    private int currentWeaponType;

    // This is filled with weapon prefabs in the unity inspector
    public Weapon[] possibleWeapons;

    void Start() {
        currentWeaponType = -1;
    }

    void Update() {}

    private Weapon FindWeapon(int type) {
        for (int i = 0; i < possibleWeapons.Length; i++) {
            Weapon weapon = possibleWeapons[i];

            if (weapon.GetComponent<Weapon>().type == type) {
                return weapon;
            }
        }

        return null;
    }

    public bool SpawnWeapon(int type) {
        if (type != currentWeaponType) {

            // Delete current player weapon (and all other children of Weapon_Placeholder
            foreach (Transform child in transform) {
                Destroy(child.gameObject);
            }

            Weapon newWeapon = FindWeapon(type);

            // Save the new weapon type and then create an instance of the weapon as a child of Weapon_Placeholder
            if (newWeapon != null) {
                currentWeaponType = type;
                Instantiate(possibleWeapons[type], transform.position, transform.rotation).transform.parent = gameObject.transform;
            }

            return true;
        }

        return false;
    }
}
