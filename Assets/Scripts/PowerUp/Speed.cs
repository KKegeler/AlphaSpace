using UnityEngine;
using System.Collections;

// Klasse für Speed-PowerUps

public class Speed : MonoBehaviour
{
#if UNITY_STANDALONE
    public void AddSpeed(PlayerMovement player)
    {
        if (player.maxSpeed < 350)
            player.maxSpeed += 10;
        if (player.start < 160)
            player.start += 2;
        if (player.acc < 5.5)
            player.acc += 0.1f;
    }
#endif

}