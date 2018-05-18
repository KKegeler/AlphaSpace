using UnityEngine;
using System.Collections;

// Komponente des Bullet-Objekts. Hier kann der Schaden festgelegt werden. 

public class ShotScript : MonoBehaviour
{
    // Schuss des Spielers oder des Gegners?
    public bool isEnemyShot = false;

    public int playerDamage = 1;
    public int enemyDamage = 1;
}