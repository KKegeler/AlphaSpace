using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighscoreNormal : GenericWindow {

    public Text platz1Name, platz1Score;
    public Text platz2Name, platz2Score;
    public Text platz3Name, platz3Score;
    public Text platz4Name, platz4Score;
    public Text platz5Name, platz5Score;

    private List<Highscore> hsList2;

    private const string dN = "---";
    private const string dS = "000";

    void Start()
    {
        hsList2 = GameControl.instance.getHighscoreList2();

        platz1Name.text = platz2Name.text = platz3Name.text = platz4Name.text = platz5Name.text = dN;
        platz1Score.text = platz2Score.text = platz3Score.text = platz4Score.text = platz5Score.text = dS;

        // Variablen befüllen
        switch (hsList2.Count)
        {
            case 0:
                break;

            case 1:
                platz1Name.text = hsList2[0].name;
                platz1Score.text = hsList2[0].score.ToString();
                break;

            case 2:
                platz1Name.text = hsList2[0].name;
                platz1Score.text = hsList2[0].score.ToString();
                platz2Name.text = hsList2[1].name;
                platz2Score.text = hsList2[1].score.ToString();
                break;

            case 3:
                platz1Name.text = hsList2[0].name;
                platz1Score.text = hsList2[0].score.ToString();
                platz2Name.text = hsList2[1].name;
                platz2Score.text = hsList2[1].score.ToString();
                platz3Name.text = hsList2[2].name;
                platz3Score.text = hsList2[2].score.ToString();
                break;

            case 4:
                platz1Name.text = hsList2[0].name;
                platz1Score.text = hsList2[0].score.ToString();
                platz2Name.text = hsList2[1].name;
                platz2Score.text = hsList2[1].score.ToString();
                platz3Name.text = hsList2[2].name;
                platz3Score.text = hsList2[2].score.ToString();
                platz4Name.text = hsList2[3].name;
                platz4Score.text = hsList2[3].score.ToString();
                break;

            default:
                platz1Name.text = hsList2[0].name;
                platz1Score.text = hsList2[0].score.ToString();
                platz2Name.text = hsList2[1].name;
                platz2Score.text = hsList2[1].score.ToString();
                platz3Name.text = hsList2[2].name;
                platz3Score.text = hsList2[2].score.ToString();
                platz4Name.text = hsList2[3].name;
                platz4Score.text = hsList2[3].score.ToString();
                platz5Name.text = hsList2[4].name;
                platz5Score.text = hsList2[4].score.ToString();
                break;
        }
    }

    public void Back()
    {
        manager.Open(6);
    }
}
