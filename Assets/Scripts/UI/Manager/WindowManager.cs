using UnityEngine;
using System.Collections;

public class WindowManager : MonoBehaviour {

    //Variablen und Array deklaration(dort kommen die einzelnen Fenster rein
    public GenericWindow[] windows;
    public int currentWindowID;
    public int defaultWindowID;
    private int dead;
    private int gameOver;
    private int imSpiel;

    void Start()
    {
        
        dead = GameControl.instance.getControlData(0);
        gameOver = GameControl.instance.getControlData(1);
        imSpiel = GameControl.instance.getControlData(3);

        if(imSpiel == 5)
        {
            defaultWindowID = 0;
        }

        if (gameOver == 5)
        {
            Open(2);
        }
        else if (dead == 5)
        {
            Open(1);
        }
        else
        {
            GenericWindow.manager = this;
            Open(defaultWindowID);
        }
    }

    //Return das derzeitig offene Window
    public GenericWindow GetWindow(int value)
    {
        return windows[value];
    }

    //sicherstellung,dass nur 1 Fenster zur Zeit an ist
    private void ToggleVisibility(int value)
    {
        var total = windows.Length;

        //geht über jedes fenster und öffnet oder schließt es
        for (var i = 0; i < total; i++)
        {
            var window = windows[i];
            if (i == value)
                window.Open();
            else if (window.gameObject.activeSelf)
                window.Close();
        }
    }

    //Fenster öffnen
    public GenericWindow Open(int value)
    {
        currentWindowID = value;
        ToggleVisibility(currentWindowID);

        return GetWindow(currentWindowID);
    }

    public void Awake()
    {
        GameControl.instance.setControlData(3, 5);
    }
}