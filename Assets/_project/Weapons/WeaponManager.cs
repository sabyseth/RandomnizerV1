using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons; // Array to hold your weapon prefabs
    public Transform weaponParent; // The parent under which weapons will spawn, usually the Main Camera
    private GameObject currentWeapon; // To keep track of the currently equipped weapon

    void Start()
    {
        // Make sure to spawn the first weapon at the start
        if (weapons.Length > 0)
        {
            SpawnWeapon(0); // Spawn the first weapon
        }
    }

    void Update()
    {
        // Check for player input to switch weapons
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0); // Switch to the first weapon
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1); // Switch to the second weapon (if available)
        }
        // Add more input checks for additional weapons if needed
    }

    void SpawnWeapon(int weaponIndex)
    {
        if (currentWeapon != null)
        {
            Destroy(currentWeapon); // Destroy the currently equipped weapon
        }

        // Instantiate the new weapon prefab under the weapon parent (the main camera)
        currentWeapon = Instantiate(weapons[weaponIndex], weaponParent.position, weaponParent.rotation);
        currentWeapon.transform.SetParent(weaponParent); // Set the camera as the parent
    }

    void SwitchWeapon(int weaponIndex)
    {
        SpawnWeapon(weaponIndex); // Call the method to spawn the selected weapon
    }
}
