using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using UnityEngine.SceneManagement;

// Speichern und Serialisieren von Daten
// Index: isDead -> 0, gameOver -> 1, NeuHighscore -> 2
// Default -> -1, Gesetzt -> 5, Error -> 3

public class GameControl : MonoBehaviour
{
    #region Variablen
    // Singleton
    public static GameControl instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private HighscoreList highscoreList = new HighscoreList();
    private static int[] controlData = { -1, -1, -1, -1 };
    public GameState gameState = GameState.campaign;
    public bool reset = false;

    private const string fileName = "/highscores.mango";
    private const string fileName2 = "/highscores2.mango";
    #endregion

    #region Init
    void Start()
    {
        // FPS drosseln (-1 -> zurücksetzen)
        Application.targetFrameRate = 144;

        // Laden
        Init();

        Load();

        if (highscoreList.hL1 == null)
            highscoreList.hL1 = new List<Highscore>();
        if (highscoreList.hL2 == null)
            highscoreList.hL2 = new List<Highscore>();

#if UNITY_EDITOR
        if (reset)
            Reset();
#endif
    }

    // Default Werte in controlData
    public void Init()
    {
        for (int i = 0; i < controlData.Length; ++i)
            controlData[i] = -1;
    }
    #endregion

    #region Speichern
    // Fügt bei neuem Highscore den Score in die Liste ein und speichert in Dateien
    public void Save(string playerName)
    {
        if (gameState == GameState.survival)
        {
            Highscore scoreData = new Highscore();
            scoreData.name = playerName;
            scoreData.score = StatisticsScript.instance.getFinalScore();

            // Highscore in Liste einfügen und ggf. Liste kürzen                                    
            highscoreList.hL1.Add(scoreData);
            highscoreList.hL1.Sort(Highscore.sortScoreDescending());

            if (highscoreList.hL1.Count > 5)
                highscoreList.hL1.RemoveAt(highscoreList.hL1.Count - 1);

            // Jedes Listenelement in eine Datei schreiben
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + fileName);

            bf.Serialize(file, highscoreList.hL1);
            file.Close();
        }
        else if (gameState == GameState.campaign)
        {
            Highscore scoreData = new Highscore();
            scoreData.name = playerName;
            scoreData.score = StatisticsScript.instance.getFinalScore();

            // Highscore in Liste einfügen und ggf. Liste kürzen                                    
            highscoreList.hL2.Add(scoreData);
            highscoreList.hL2.Sort(Highscore.sortScoreDescending());

            if (highscoreList.hL2.Count > 5)
                highscoreList.hL2.RemoveAt(highscoreList.hL2.Count - 1);

            // Jedes Listenelement in eine Datei schreiben
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + fileName2);

            bf.Serialize(file, highscoreList.hL2);
            file.Close();
        }
    }

    // Lädt die Highscores aus den Dateien in die Liste
    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
            List<Highscore> scoreData = (List<Highscore>)bf.Deserialize(file);
            file.Close();

            highscoreList.hL1 = scoreData;
            highscoreList.hL1.Sort(Highscore.sortScoreDescending());
        }

        if (File.Exists(Application.persistentDataPath + fileName2))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + fileName2, FileMode.Open);
            List<Highscore> scoreData = (List<Highscore>)bf.Deserialize(file);
            file.Close();

            highscoreList.hL2 = scoreData;
            highscoreList.hL2.Sort(Highscore.sortScoreDescending());
        }
    }

    // Löscht alle Highscoredaten
    private void Reset()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
            File.Delete(Application.persistentDataPath + fileName);

        if (File.Exists(Application.persistentDataPath + fileName2))
            File.Delete(Application.persistentDataPath + fileName2);

        highscoreList.hL1.Clear();
        highscoreList.hL2.Clear();
    }
    #endregion

    #region Coroutines
    // Delay beim Laden
    public void LoadDelayed()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(0);
    }

    public void StartFreeze()
    {
        StartCoroutine(Freeze());
    }

    public IEnumerator Freeze()
    {
        Time.timeScale = 0.5f;

        yield return new WaitForSeconds(0.015f);

        Time.timeScale = 1;

    }
    #endregion

    #region Getter Setter
    // Getter
    public List<Highscore> getHighscoreList1()
    {
        return highscoreList.hL1;
    }

    public List<Highscore> getHighscoreList2()
    {
        return highscoreList.hL2;
    }

    // Getter controlData
    public int getControlData(int index)
    {
        if (index < controlData.Length && index >= 0)
            return controlData[index];
        else
            return -3;
    }

    // Setter controlData
    public void setControlData(int index, int value)
    {
        if (index < controlData.Length)
            controlData[index] = value;
        else
            Debug.LogError("Falscher Index in setControlData");
    }

    // Getter gameState
    public GameState getGameState()
    {
        return gameState;
    }

    // Setter gameState
    public void setGameState(GameState newGameState)
    {
        gameState = newGameState;
    }
    #endregion

}

#region Klassen und enum
// Klasse die serialisiert wird

[Serializable]
public class Highscore
{
    public string name;
    public float score;

    // Klasse für absteigende Sortierung
    private class sortScoreDescendingHelper : IComparer<Highscore>
    {
        public int Compare(Highscore x, Highscore y)
        {
            Highscore h1 = x;
            Highscore h2 = y;

            if (h1.score < h2.score)
                return 1;

            if (h1.score > h2.score)
                return -1;

            else
                return 0;
        }

    }

    // Methode um das IComparer-Objekt zurückzugeben
    public static IComparer<Highscore> sortScoreDescending()
    {
        return new sortScoreDescendingHelper();
    }

}

[Serializable]
public class HighscoreList
{
    public List<Highscore> hL1;
    public List<Highscore> hL2;
}

public enum GameState
{
    start = -1,
    campaign,
    survival
}
#endregion