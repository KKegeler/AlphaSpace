using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyboardWindow : GenericWindow {

    public Text inputField;
    public int maxCharacters = 7;

    private float delay = 0;
    private float curserDelay = .5f;
    private bool blink;
    public bool shift = false;
    private string _text = string.Empty;
    private int actualLength = 0;

    void Start()
    {
        GameControl.instance.setControlData(1, -1);
        GameControl.instance.setControlData(2, -1);
        //actuallength = _text.Length;
    }

    void Update()
    {
        var text = _text;
        

        if (_text.Length < maxCharacters)
        {
            text += "_";

            if (blink)
            {
                text = text.Remove(text.Length - 1);
            }
        }

        inputField.text = text;

        delay += Time.deltaTime;
        if (delay > curserDelay)
        {
            delay = 0;
            blink = !blink;
        }

        if (shift)
        {
            string test = Input.inputString;
            _text += test.ToUpper();
            shift = false;
        }

        if (Input.anyKeyDown)
        {
            OnKeyPress(Input.inputString);
            
            //if (shift)
            //{
            //    string test = Input.inputString;
            //    _text += test.ToUpper();
            //    shift = false;
            //}
            //if (!shift)
            //{
            //    actuallength++;
            //    //shift = true;
            //}
            //else
            //{
            //    shift = false;
            //}
            //Debug.Log("Länge" + actuallength);
        }
    }

    public void OnKeyPress(string key)
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    Debug.Log("Enter gedrückt if");
        //    PlayerPrefs.SetString(_text, "0");
        //    Highscore();

        //}

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _text = _text.Remove(actualLength-1);
            actualLength--;
            
        }

        //if (shift)
        //{
        //    _text += key.ToUpper();
        //    shift = false;
        //}else 
        if (_text.Length < maxCharacters)
        {
            _text += key;
            
        }       
    }

    public void Shift()
    {
        shift = true;
    }

    public void Highscore()
    {
        GameControl.instance.Save(_text);
        SceneManager.LoadScene(0);
    }

}