using UnityEngine;
using System.Collections;

// Das Bullet-Objekt wird in der Update-Funktion nach rechts bzw. links bewegt. 

public class BulletObject : PoolObject
{
    public float bulletSpeed = 13.0f;

    // Beschleunigt die Kugel
	void Update ()
    {
        if (gameObject.GetComponent<ShotScript>().isEnemyShot)
            transform.Translate(Vector3.left * Time.deltaTime * bulletSpeed);
        else
            transform.Translate(Vector3.right * Time.deltaTime * bulletSpeed);
    }

    public override void OnObjectReuse()
    {
        
    }

}