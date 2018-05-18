using UnityEngine;
using System.Collections;

public class BossWeaponScript : MonoBehaviour
{
    protected float shootCooldown;
    public float fireCooldown = 1f;
    public float minFireCooldown = 1f;
    public float maxFireCooldown = 2f;
    public GameObject bullet;
    public GameObject spawn1;
    public GameObject spawn2;

    void Start()
    {
        if (!bullet)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        shootCooldown = Random.Range(minFireCooldown, maxFireCooldown);
    }

    void Update()
    {
        if (shootCooldown > 0f)
            shootCooldown -= Time.deltaTime;

        // Schießen
        if (shootCooldown <= 0f)
        {
            shootCooldown = fireCooldown;
            PoolManager.instance.ReuseObject(bullet, spawn1.transform.position + 
                Vector3.left, Quaternion.identity);
            PoolManager.instance.ReuseObject(bullet, spawn2.transform.position +
                Vector3.left, Quaternion.identity);
            SoundManager.instance.PlayEffect(1, 0.1f);
        }
    }
}