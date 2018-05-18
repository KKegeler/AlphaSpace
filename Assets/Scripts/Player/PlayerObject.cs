using UnityEngine;
using System.Collections;

public class PlayerObject : PoolObject
{
    public BaseHealthScript healthScript;
    public ParticleSystem hitSystem;
    public ParticleSystem destroySystem;

    // Singleton
    static PlayerObject _instance;

    public static PlayerObject instance
    {
        get
        {
            if (!_instance)
                _instance = FindObjectOfType<PlayerObject>();

            return _instance;
        }
    }

    void Start()
    {
        if (!healthScript || !hitSystem || !destroySystem)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");
    }

    public override void OnObjectReuse()
    {
        healthScript.health = healthScript.getOriginalPlayerHealth();
        healthScript.isDead = false;
    }

    public void playDestroySystem(Transform _transform)
    {
        Instantiate(destroySystem, _transform.position, _transform.rotation);
    }

    public void playHitSystem(Transform _transform)
    {
        Instantiate(hitSystem, _transform.position, Quaternion.Euler(0, 0, 270));
    }

}