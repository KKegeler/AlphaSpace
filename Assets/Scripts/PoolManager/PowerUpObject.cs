using UnityEngine;
using System.Collections;

// PowerUp-Objekt wird nach links bewegt

public class PowerUpObject : PoolObject
{
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime);
    }

    public override void OnObjectReuse()
    {

    }

}