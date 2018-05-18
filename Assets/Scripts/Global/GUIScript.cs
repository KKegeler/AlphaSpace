using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScript : MonoBehaviour
{
    public Text scoreAnzeige;
    public Slider healthSlider;
    public GameObject player;
    private BaseHealthScript bHealth;

    private float score, oldScore = -1f;
    private int health, oldHealth = 5;

    void Start()
    {
        if (!scoreAnzeige || !healthSlider || !player)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        bHealth = player.GetComponent<BaseHealthScript>();
    }

    void Update ()
    {
        score = StatisticsScript.instance.getScore();
        if (score != oldScore)
        {
            scoreAnzeige.text = score.ToString();
            oldScore = score;
        }

        health = bHealth.getCurrentHealth();
        if(health != oldHealth)
        {
            healthSlider.value = health;
            oldHealth = health;
        }

        if (healthSlider.value == 0)
            healthSlider.gameObject.SetActive(false);
    }

}