using UnityEngine;
using System.Collections;

// In der OnObjectReuse-Funktion wird der isDead wieder auf false gesetzt und
// die Lebenspunkte auf den Startwert zurückgesetzt.

public class EnemyObject : PoolObject
{
    public HealthScript healthScript;
    public ParticleSystem hitSystem;
    public ParticleSystem destroySystem;
    public EnemyMovementScript enemyMovementScript;

    // Singleton
    static EnemyObject _instance;

    public static EnemyObject instance
    {
        get
        {
            if (!_instance)
                _instance = FindObjectOfType<EnemyObject>();

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
        healthScript.health = healthScript.getOriginalHealth();
        healthScript.isDead = false;
        if (GameControl.instance.gameState == GameState.campaign)
            enemyMovementScript.onReuse();
    }

    public void playDestroySystem(Transform _transform)
    {
        Instantiate(destroySystem, _transform.position, _transform.rotation);
    }

    public void playHitSystem(Transform _transform)
    {
        Instantiate(hitSystem, _transform.position, Quaternion.Euler(0,0,270));
    }

}