using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartWindow : GenericWindow
{
    public Button continueButton;
    

    public override void Open()
    {
        var canContinue = false;
        continueButton.gameObject.SetActive(canContinue);

        if (continueButton.gameObject.activeSelf)
        {
            firstSelected = continueButton.gameObject;
        }
        base.Open();
    }

    public void NewGame()
    {
        manager.Open(5);
    }

    public void Continue()
    {
        Debug.Log("Continue Pressed");
    }

    public void Options()
    {
        manager.Open(3);
    }

    public void Highscores()
    {
        manager.Open(6);
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Start()
    {
        if (GameControl.instance.getControlData(1) != 5)
            MusicManager.instance.PlayMusic(0);
        else
            MusicManager.instance.PlayMusic(4);
    }

}