using UnityEngine;
using System.Collections;

// Klasse für Health-PowerUps

public class Health : MonoBehaviour
{
    public void AddHealth(BaseHealthScript baseHealth)
    {
        if (baseHealth.health < 5)
            baseHealth.health++;
    }
}