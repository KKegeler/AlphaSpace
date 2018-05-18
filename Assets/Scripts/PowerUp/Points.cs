using UnityEngine;
using System.Collections;

// Klasse für Points-PowerUps

public class Points : MonoBehaviour
{
    public void AddPoints()
    {
        float points = 500 + 500 * StatisticsScript.instance.timeBonus;
        StatisticsScript.instance.AddScore((int)points);
        StatisticsScript.instance.killCount -= 1;
    }

}