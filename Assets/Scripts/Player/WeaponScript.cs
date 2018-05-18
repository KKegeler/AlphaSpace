using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


// Hier wird der Schuss des Spielers festgelegt.

public class WeaponScript : BaseWeaponScript
{
    // Singleton
    static WeaponScript _instance;
    public static WeaponScript instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<WeaponScript>();

            return _instance;
        }
    }

    public bool pause = false;
    public GameObject PauseMenu;

    void Start()
    {
        if (!bullet)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        shootCooldown = 0f;
        pause = false;
    }

    // Wurde der Fire-Botton gedrückt?
    void Update ()
    {
        if (shootCooldown > 0f)
            shootCooldown -= Time.deltaTime;

        // Schießen
        if (!pause && (Input.GetMouseButton(0) || Input.GetButton("Fire1")) && CanAttack())
        {
            shootCooldown = fireCooldown;
            PoolManager.instance.ReuseObject(bullet, transform.position
                + Vector3.right * 1.5f, Quaternion.identity);
            if (tag == "Player")
                SoundManager.instance.PlayEffect(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && tag == "Player")
        {
            pause = !pause;
            if (pause)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
            }
        }
    }

}