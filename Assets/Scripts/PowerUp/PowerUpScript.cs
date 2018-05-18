using UnityEngine;
using System.Collections;

// Hier werden PowerUps zum Aufsammeln generiert.

public class PowerUpScript : MonoBehaviour
{
    #region Variablen
    // Singleton
    static PowerUpScript _instance;

    public static PowerUpScript instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<PowerUpScript>();

            return _instance;
        }
    }

    public GameObject prefab1;              // PlayerMovement
    public GameObject prefab2;              // FireRate
    public GameObject prefab3;              // PlayerHealth
    public GameObject prefab4;              // AssistantCount
    public GameObject prefab5;              // Points

    private int genNumber;
    private int buffer;
    private Vector3 powerUpPosition;
    private Quaternion powerUpRotation;

    public bool test = false;
    #endregion

    #region Init
    void Start()
    {
        if (!prefab1 || !prefab2 || !prefab3 || !prefab4 || !prefab5)
            Debug.LogError("Objekt in " + gameObject.name + " nicht gefunden!");

        buffer = 1;
    }
    #endregion

    #region Methoden
    // Erzeugt ein PowerUp
    public void GeneratePowerUp(Transform enemyTransform, bool _isStrongEnemy, int offset)
    {
        bool isStrongEnemy = _isStrongEnemy;
        int x = offset;                   

        if(isStrongEnemy)
            buffer = 1;

        if (GameControl.instance.gameState == GameState.survival)
            --buffer;
        else
            buffer -= 2;

        // Chance auf ein PowerUp
        if (test)
            genNumber = 0;
        else
        {
            if (GameControl.instance.gameState == GameState.survival)
                genNumber = Random.Range(0, 20 - x);
            else
                genNumber = Random.Range(0, 12 - x);
        }

        if (genNumber != 0 || buffer > 0)
            return;

        if (!test)
            buffer = 10;

        // Position des PowerUps
        powerUpPosition = enemyTransform.position;
        powerUpRotation = Quaternion.identity;

        // Welches PowerUp wird generiert?
        genNumber = Random.Range(0, 100);

        if (genNumber < 20)
            genNumber = 1;
        else if (genNumber >= 20 && genNumber < 40)
            genNumber = 2;
        else if (genNumber >= 40 && genNumber < 60)
            genNumber = 3;
        else if (genNumber >= 60 && genNumber < 80)
            genNumber = 4;
        else if (genNumber >= 80)
            genNumber = 5;

        switch (genNumber)
        {
            // Geschwindigkeit des Spielers wird erhöht
            case 1:
                PoolManager.instance.ReuseObject(prefab1, powerUpPosition, powerUpRotation);
                break;

            // Feuerrate des Spielers wird erhöht
            case 2:
                PoolManager.instance.ReuseObject(prefab2, powerUpPosition, powerUpRotation);
                break;

            // Gesundheit des Spielers wiederherstellen
            case 3:
                PoolManager.instance.ReuseObject(prefab3, powerUpPosition, powerUpRotation);
                break;

            // AssistantCount wird erhöht
            case 4:
                PoolManager.instance.ReuseObject(prefab4, powerUpPosition, powerUpRotation);
                break;

            // Score wird erhöht
            case 5:
                PoolManager.instance.ReuseObject(prefab5, powerUpPosition, powerUpRotation);
                break;

            // Default: Fehlermeldung
            default:
                Debug.LogError("Fehler beim Generieren des PowerUps!");
                break;
        }
    }
    #endregion

}