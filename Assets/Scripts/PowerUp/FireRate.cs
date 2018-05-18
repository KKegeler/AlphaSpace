using UnityEngine;
using System.Collections;

// Klasse für FireRate-PowerUps

public class FireRate : MonoBehaviour
{
    public void AddFireRate(WeaponScript weapon)
    {
        if (weapon.fireCooldown > 0.2f)
            weapon.fireCooldown -= 0.01f;
    }

}