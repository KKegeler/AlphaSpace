using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

// Verwaltet die Statistiken des Spielers

public class StatisticsScript : MonoBehaviour
{
    #region Variablen
    // Singleton
    public static StatisticsScript instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public float score = 0f;
    public float playerDamage = 0f;
    public float enemyDamage = 0f;
    public float killCount = 0f;
    public float missedShots = 0f;
    public float playerDeath = 0f;
    public float playerTime = 0;
    public float timeBonus = 0f;
    public float finalScore = 0f;
    public bool timeStopped;
    #endregion

    #region Init
    void Start()
    {
        if (SceneManager.GetSceneByName("MainScene") == SceneManager.GetActiveScene())
            timeStopped = false;
        else
            timeStopped = true;
    }
    #endregion

    #region Update
    // Zählt playerTime hoch
    void Update()
    {
        if(!timeStopped)
            playerTime += Time.deltaTime;
        timeBonus = (int)(playerTime / 60);
    }
    #endregion

    #region Methoden
    // Setzt Werte zurück
    public void Reset()
    {
        score = 0f;
        playerDamage = 0f;
        enemyDamage = 0f;
        killCount = 0f;
        missedShots = 0f;
        playerDeath = 0f;
        playerTime = 0f;
        timeBonus = 0f;
        finalScore = 0f;
        timeStopped = false;
    }

    // Addiert einen Wert auf den HighScore
    public void AddScore(int otherScore)
    {
        score += otherScore;
        ++killCount;
    }

    // Schaden, den der Spieler an Gegnern gemacht hat
    public void AddPlayerDamage(int damage)
    {
        playerDamage += damage;
    }

    // Schaden, den die Gegner am Spieler gemacht haben
    public void AddEnemyDamage(int damage)
    {
        enemyDamage += damage;
    }

    // Missed Shots
    public void AddShots()
    {
        ++missedShots;
    }

    // Tode
    public void AddDeath()
    {
        ++playerDeath;
    }

    // Berechnung des FinalScore nach Berücksichtigung aller Parameter
    public void CalculateFinalScore()
    {
        float temp1 = (playerDamage / (1 + missedShots)) / (1 + playerDeath);
        float temp2 = (killCount / (1 + playerDeath)) / (1 + enemyDamage);
        float temp3 = (Mathf.Log10(1 + temp1) + Mathf.Log10(1 + temp2));

        finalScore = Mathf.Round(score * (timeBonus / 10 + temp3));
    }

    // Bei Tod des Spielers
    public void Death()
    {
        CalculateFinalScore();

        List<Highscore> hsList = new List<Highscore>();
        List<Highscore> hsList2 = new List<Highscore>();

        if (GameControl.instance.gameState == GameState.survival)
        {
            hsList = GameControl.instance.getHighscoreList1();
            if (hsList.Count < 5 || finalScore > hsList[hsList.Count - 1].score)
                GameControl.instance.setControlData(2, 5);
        }
        else if (GameControl.instance.gameState == GameState.campaign)
        {
            hsList2 = GameControl.instance.getHighscoreList2();
            if (hsList2.Count < 5 || finalScore > hsList2[hsList2.Count - 1].score)
                GameControl.instance.setControlData(2, 5);
        }

        timeStopped = true;
    }
    #endregion

    #region Getter
    public float getScore()
    {
        return score;
    }

    public float getPlayerDamage()
    {
        return playerDamage;
    }

    public float getEnemyDamage()
    {
        return enemyDamage;
    }

    public float getKillCount()
    {
        return killCount;
    }

    public float getMissedShots()
    {
        return missedShots;
    }

    public float getPlayerDeath()
    {
        return playerDeath;
    }

    public int getPlayerTime()
    {
        return (int)playerTime;
    }

    public float getFinalScore()
    {
        return finalScore;
    }
    #endregion

}