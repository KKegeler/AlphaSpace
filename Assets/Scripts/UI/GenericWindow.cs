using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//Grundskript für alle Fenster

public class GenericWindow : MonoBehaviour
{   
    public static WindowManager manager;

    //Zuerst selektierter Button
    public GameObject firstSelected;

    //Methode um auf das EventSystem zugreifen zu können
    protected EventSystem eventSystem
    {
        get { return GameObject.Find("EventSystem").GetComponent<EventSystem>(); }
    }

    //Zuerst selektierter Button wird gesetzt
    public virtual void OnFocus()
    {
        eventSystem.SetSelectedGameObject(firstSelected);
    }

    //Um die Verschiedenen Menüs anzuzeigen bzw auszublenden
    protected virtual void Display(bool value)
    {
        bool test = value;
        gameObject.SetActive(test);
    }

    //Fenster öffnen
    public virtual void Open()
    {
        Display(true);
        OnFocus();
    }

    //Fenster schließen
    public virtual void Close()
    {
        Display(false);
    }

}