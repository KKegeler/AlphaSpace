using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using UnityEngine.UI;

// Basisklasse für Lebensverwaltung.
// Dieses Script wird an den Spieler angehängt.

public class BaseHealthScript : MonoBehaviour
{
    public bool isDead = false;
    public int health;
    protected bool isEnemy = false;
    private int originalPlayerHealth;

    void Start()
    {
        if(health <= 0)
            health = 5;

        originalPlayerHealth = 5;
    }

    // Zieht den Schaden von den Leben ab und überprüft ob die Leben auf 0 sind
    public virtual void Damage(int damage)
    {
        CameraShake.instance.ShakeCamera();

        health -= damage;
        StatisticsScript.instance.AddEnemyDamage(damage);

        if (health <= 0)
        {
            SoundManager.instance.PlayEffect(4, 0.5f);
            isDead = true;
            StatisticsScript.instance.AddDeath();
        }
        else
            SoundManager.instance.PlayEffect(3);

        if (isDead)
        {
            StatisticsScript.instance.Death();
            GameControl.instance.setControlData(0, 5);
            PlayerObject.instance.playDestroySystem(gameObject.transform);
            GameControl.instance.LoadDelayed();
            gameObject.SetActive(false);
        }
    }

    // Ist ein Schuss/Gegner mit dem Objekt kollidiert?
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        EnemyObject enemy = otherCollider.gameObject.GetComponent<EnemyObject>();

        if (shot)
        {
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.playerDamage);
                shot.gameObject.SetActive(false);
                PlayerObject.instance.playHitSystem(gameObject.transform);
                SoundManager.instance.PlayEffect(3);
            }
        }
        else if (enemy && !isEnemy)
        {
            int collisionDamage = enemy.gameObject.GetComponent<HealthScript>().getOriginalHealth();

            Damage(collisionDamage);
            enemy.gameObject.GetComponent<HealthScript>().Damage(originalPlayerHealth);
        }
    }

    public int getOriginalPlayerHealth()
    {
        return originalPlayerHealth;
    }

    public int getCurrentHealth()
    {
        return health;
    }

}