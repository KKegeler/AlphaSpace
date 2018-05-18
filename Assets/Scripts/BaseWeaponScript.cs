using UnityEngine;
using System.Collections;

public class BaseWeaponScript : MonoBehaviour
{
    protected float shootCooldown;
    public float fireCooldown = 0.25f;
    public GameObject bullet;

    void Start()
    {
        if (!bullet)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0f)
            shootCooldown -= Time.deltaTime;

        // Schießen
        if ((Input.GetMouseButton(0) || Input.GetButton("Fire1")) && CanAttack())
        {
            shootCooldown = fireCooldown;
            PoolManager.instance.ReuseObject(bullet, transform.position + Vector3.right, Quaternion.identity);
        }
    }

    // Ist der Cooldown abgelaufen?
    protected bool CanAttack()
    {
        return (shootCooldown <= 0f);
    }

}