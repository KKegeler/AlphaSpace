using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Gamemodi : GenericWindow
{

    public void NormalGame()
    {
        GameControl.instance.gameState = GameState.campaign;
        StatisticsScript.instance.Reset();
        SceneManager.LoadScene("Campaign");
        MusicManager.instance.PlayRandomMusic();
        //Debug.Log("Kampagne starten");
    }

    public void EndlessGame()
    {
        GameControl.instance.gameState = GameState.survival;
        StatisticsScript.instance.Reset();
        GameControl.instance.Init();
        SceneManager.LoadScene("MainScene");
        MusicManager.instance.PlayRandomMusic();
    }

    public void Back()
    {
        manager.Open(0);
    }
}
