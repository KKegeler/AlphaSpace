using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverWindow : GenericWindow
{
    //GameObjects zur Anzeige und Variablen
    public Text leftStatsLabel1;
    public Text leftStatsLabel2;
    public Text leftStatsLabel3;
    public Text leftStatsLabel4;
    public Text leftStatsValue1;
    public Text leftStatsValue2;
    public Text leftStatsValue3;
    public Text leftStatsValue4;
    public Text rightStatsLabel1;
    public Text rightStatsLabel2;
    public Text rightStatsLabel3;
    public Text rightStatsValue1;
    public Text rightStatsValue2;
    public Text rightStatsValue3;
    public Text scoreValue;
    public float statsDelay = 1f;
    public int totalStats = 7;
    public int statsPerColoumn = 4;
    
    
    private const float waitTime = 0.5f;


    void Start()
    {
        GameControl.instance.setControlData(0, -1);
        MusicManager.instance.PlayMusic(4);
        StartCoroutine(ShowNextStat());
    }

    /*private void UpdateStatText(Text label, Text value)
    {
        
        label.text += "Stat " + currentStat + "\n";
        value.text += Random.Range(0, 1000).ToString("D4") + "\n";
    }*/

    //Anzeige der einzelnen Werte
    private IEnumerator ShowNextStat()
    {
        
        yield return new WaitForSeconds(waitTime);

        leftStatsValue1.text = StatisticsScript.instance.getScore().ToString();

        yield return new WaitForSeconds(waitTime);

        leftStatsValue2.text = StatisticsScript.instance.getPlayerDamage().ToString();

        yield return new WaitForSeconds(waitTime);

        leftStatsValue3.text = StatisticsScript.instance.getKillCount().ToString();

        yield return new WaitForSeconds(waitTime);

        rightStatsValue1.text = StatisticsScript.instance.getMissedShots().ToString();

        yield return new WaitForSeconds(waitTime);

        rightStatsValue2.text = StatisticsScript.instance.getEnemyDamage().ToString();

        yield return new WaitForSeconds(waitTime);

        rightStatsValue3.text = StatisticsScript.instance.getPlayerTime().ToString();

        yield return new WaitForSeconds(waitTime);

        scoreValue.text = StatisticsScript.instance.getFinalScore().ToString();

        #region long_comment
        /*WaitForSeconds
        //TakeInfo[] importedTakeInfos
        //float time = TakeInfo.startTime;

        //if (currentStat > totalStats -1)
        //{
        //    scoreValue.text = StatisticsScript.instance.getFinalScore().ToString(); ;
        //    //scoreValue.text = Random.Range(0, 1000000000).ToString("D10");
        //    currentStat = -1;
        //    return;
        //}

        //delay += Time.deltaTime;
        //if (delay > statsDelay && currentStat != -1)
        //{

        //    delay = 0;
        //}

        //leftStatsLabel1.text = "Score: ";
        //leftStatsValue1.text = StatisticsScript.instance.getScore().ToString();

        //leftStatsLabel2.text = "Damage: ";
        //leftStatsValue2.text = StatisticsScript.instance.getPlayerDamage().ToString();
        //leftStatsLabel3.text = "Kills: ";
        //leftStatsValue3.text = StatisticsScript.instance.getKillCount().ToString();
        //rightStatsLabel1.text = "Missed Shots: ";
        //rightStatsValue1.text = StatisticsScript.instance.getMissedShots().ToString();
        //rightStatsLabel2.text = "Enemy Damage: ";
        //rightStatsValue2.text = StatisticsScript.instance.getEnemyDamage().ToString();
        //rightStatsLabel3.text = "Zeit: ";
        //rightStatsValue3.text = StatisticsScript.instance.getPlayerTime().ToString();
        //scoreValue.text = StatisticsScript.instance.getFinalScore().ToString();

        //if (currentStat < statsPerColoumn)
        //{
        //    //UpdateStatText(leftStatsLabel, leftStatsValue);
        //}
        //else
        //{
        //    //UpdateStatText(rightStatsLabel, rightStatsValue);
        //}

        //++currentStat;*/
        #endregion
    }

    //Textanzeige zurücksetzen
    public void ClearText()
    {
        leftStatsValue1.text = string.Empty;
        leftStatsValue2.text = string.Empty;
        leftStatsValue3.text = string.Empty;
        leftStatsValue4.text = string.Empty;
        rightStatsValue1.text = string.Empty;
        rightStatsValue2.text = string.Empty;
        rightStatsValue3.text = string.Empty;
        scoreValue.text = string.Empty;
    }

    //Fenster Öffnen Methode überschrieben
    public override void Open()
    {
        ClearText();
        base.Open();
    }

    //Fenster schließen Methode überschrieben
    public override void Close()
    {
        base.Close();

    }

    public void OnNext()
    {
        if (GameControl.instance.getControlData(2) == 5)
            GameControl.instance.setControlData(1, 5);

        SceneManager.LoadScene(0);
    }
    
}