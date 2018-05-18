using UnityEngine;
using System.Collections;

// Verwaltet Lebenspunkte und ruft die Instanz des Score-Scripts auf.
// Zerstört die Bullet-Objekte beim Einschlag.

public class HealthScript : BaseHealthScript
{
    #region Variablen
    public int healthOffset = 0;
    public int score = 100;
    public bool isStrongEnemy;
    public int powerUpOffset;
    public bool isBoss;
    private int originalHealth;
    private int damageCount;
    #endregion

    #region Init
    void Start()
    {
        isEnemy = true;
        health = 2 + healthOffset;
        originalHealth = health;
    }
    #endregion

    #region Schaden
    // Zieht den Schaden von den Leben ab und überprüft ob die Leben auf 0 sind
    // Wenn ja, wird die Score-Instanz mit dem Score aufgerufen
    public override void Damage(int damage)
    {
        health -= damage;
        StatisticsScript.instance.AddPlayerDamage(damage);

        GameControl.instance.StartFreeze();

        if (health <= 0)
        {
            isDead = true;
            StatisticsScript.instance.AddScore(score);
            PowerUpScript.instance.GeneratePowerUp(gameObject.transform, isStrongEnemy, powerUpOffset);

            if (isBoss)
            {
                StatisticsScript.instance.Death();
                GameControl.instance.setControlData(0, 5);
                GameControl.instance.LoadDelayed();
            }
        }

        if (isDead)
        {
            EnemyObject.instance.playDestroySystem(gameObject.transform);
            SoundManager.instance.PlayEffect(2);
            gameObject.SetActive(false);
        }
        else
        {
            EnemyObject.instance.playHitSystem(gameObject.transform);
            SoundManager.instance.PlayEffect(3, 0.01f);
        }
    }
    #endregion

    #region Getter
    public int getOriginalHealth()
    {
        return originalHealth;
    }
    #endregion

}