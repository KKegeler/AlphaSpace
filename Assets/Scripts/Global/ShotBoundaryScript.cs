using UnityEngine;
using System.Collections;

// Zerstört die Schüsse beim Verlassen des Sichtfeldes

public class ShotBoundaryScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();

        if (shot && !shot.isEnemyShot)
            StatisticsScript.instance.AddShots();

        if (otherCollider)
            otherCollider.gameObject.SetActive(false);

    }
}