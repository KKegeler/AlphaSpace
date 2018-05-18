using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public void BackToMenu()
    {
        //SceneManager.UnloadScene(1);
        //player.SetActive(false);
        SceneManager.LoadScene(0);
        WeaponScript.instance.pause = false;
        Time.timeScale = 1;

    }

    public void Continue()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        WeaponScript.instance.pause = false;
    }

    
}
