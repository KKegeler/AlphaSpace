using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighscoresWindow : GenericWindow
{
    public Text platz1Name, platz1Score;
    public Text platz2Name, platz2Score;
    public Text platz3Name, platz3Score;
    public Text platz4Name, platz4Score;
    public Text platz5Name, platz5Score;

    private List<Highscore> hsList1;

    private const string dN = "---";
    private const string dS = "000";

    void Start()
    {
        hsList1 = GameControl.instance.getHighscoreList1();

        platz1Name.text = platz2Name.text = platz3Name.text = platz4Name.text = platz5Name.text = dN;
        platz1Score.text = platz2Score.text = platz3Score.text = platz4Score.text = platz5Score.text = dS;

        // Variablen befüllen
        switch (hsList1.Count)
        {
            case 0:
                break;

            case 1:
                platz1Name.text = hsList1[0].name;
                platz1Score.text = hsList1[0].score.ToString();
                break;

            case 2:
                platz1Name.text = hsList1[0].name;
                platz1Score.text = hsList1[0].score.ToString();
                platz2Name.text = hsList1[1].name;
                platz2Score.text = hsList1[1].score.ToString();
                break;

            case 3:
                platz1Name.text = hsList1[0].name;
                platz1Score.text = hsList1[0].score.ToString();
                platz2Name.text = hsList1[1].name;
                platz2Score.text = hsList1[1].score.ToString();
                platz3Name.text = hsList1[2].name;
                platz3Score.text = hsList1[2].score.ToString();
                break;

            case 4:
                platz1Name.text = hsList1[0].name;
                platz1Score.text = hsList1[0].score.ToString();
                platz2Name.text = hsList1[1].name;
                platz2Score.text = hsList1[1].score.ToString();
                platz3Name.text = hsList1[2].name;
                platz3Score.text = hsList1[2].score.ToString();
                platz4Name.text = hsList1[3].name;
                platz4Score.text = hsList1[3].score.ToString();
                break;

            default:
                platz1Name.text = hsList1[0].name;
                platz1Score.text = hsList1[0].score.ToString();
                platz2Name.text = hsList1[1].name;
                platz2Score.text = hsList1[1].score.ToString();
                platz3Name.text = hsList1[2].name;
                platz3Score.text = hsList1[2].score.ToString();
                platz4Name.text = hsList1[3].name;
                platz4Score.text = hsList1[3].score.ToString();
                platz5Name.text = hsList1[4].name;
                platz5Score.text = hsList1[4].score.ToString();
                break;
        }
    }

    public void Back()
    {
        manager.Open(6);
    }

}