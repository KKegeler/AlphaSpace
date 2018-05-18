using UnityEngine;
using System.Collections;

public class EnemyWeaponScript : MonoBehaviour
{
    protected float shootCooldown;
    public float fireCooldown = 1f;
    public float minFireCooldown = 1f;
    public float maxFireCooldown = 2f;
    public GameObject bullet;

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
            PoolManager.instance.ReuseObject(bullet, transform.position + 
                Vector3.left, Quaternion.identity);
            SoundManager.instance.PlayEffect(1, 0.1f);
        }
    }

}