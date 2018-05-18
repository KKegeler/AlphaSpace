using UnityEngine;
using System.Collections;

// Hier werden die PowerUps auf die Attribute des Spielers gerechnet

public class CollectPowerUp : MonoBehaviour
{
    #region Variablen
    private PlayerMovement pMovement;
    private WeaponScript pWeapon;
    private WeaponScript aWeapon;
    private WeaponScript aWeapon2;
    private BaseHealthScript pBHealth;
    public GameObject assistant;
    public GameObject assistant2;
    public int assistantCount;
    #endregion

    #region Init
    void Start()
    {
        if (!assistant || !assistant2)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        pMovement = gameObject.GetComponent<PlayerMovement>();
        pWeapon = gameObject.GetComponent<WeaponScript>();
        aWeapon = assistant.GetComponent<WeaponScript>();
        aWeapon2 = assistant2.GetComponent<WeaponScript>();
        pBHealth = gameObject.GetComponent<BaseHealthScript>();
        assistantCount = 0;
    }
    #endregion

    #region OnTriggerEnter
    // Bei Kontakt mit PowerUp wird die entsprechende Funktion aufgerufen
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PowerUpObject>())
        {
            SoundManager.instance.PlayEffect(5);

            FireRate powerUpFireRate = collider.gameObject.GetComponent<FireRate>();
            Health powerUpHealth = collider.gameObject.GetComponent<Health>();
            Assistant powerUpAssistant = collider.gameObject.GetComponent<Assistant>();
            Points powerUpPoints = collider.gameObject.GetComponent<Points>();

#if UNITY_STANDALONE
            Speed powerUpSpeed = collider.gameObject.GetComponent<Speed>();

            if (powerUpSpeed)
            {
                powerUpSpeed.AddSpeed(pMovement);
                powerUpSpeed.gameObject.SetActive(false);
            }
#endif

            if (powerUpFireRate)
            {
                powerUpFireRate.AddFireRate(pWeapon);
                powerUpFireRate.AddFireRate(aWeapon);
                powerUpFireRate.AddFireRate(aWeapon2);
                powerUpFireRate.gameObject.SetActive(false);
            }
            else if (powerUpHealth)
            {
                powerUpHealth.AddHealth(pBHealth);
                powerUpHealth.gameObject.SetActive(false);
            }
            else if (powerUpPoints)
            {
                powerUpPoints.AddPoints();
                powerUpPoints.gameObject.SetActive(false);
            }
            else if (powerUpAssistant)
            {
                assistantCount = powerUpAssistant.AddAssistantCount(assistantCount);
                powerUpAssistant.gameObject.SetActive(false);

                if (assistantCount == 3)
                    assistant.SetActive(true);
                else if (assistantCount == 5)
                    assistant2.SetActive(true);
            }
        }
    }
    #endregion

}