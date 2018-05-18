using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemy2;
    public float spawnTime = 3f; 
    public Transform[] spawnPoints;
    public bool campaignOn = false;
    public int maxNumberOfEnemies = 2;

    void Start ()
    {
        if (!enemy || !enemy2)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        InvokeRepeating("Spawn", spawnTime, spawnTime);

        if (GameControl.instance.gameState == GameState.campaign)
        {
            campaignOn = true;
        }
    }

    void Spawn()
    {
        if (campaignOn)
        {

        }
        
        else
        {
            int numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (numberOfEnemies <= maxNumberOfEnemies)
            {

                int spawnPointIndex = Random.Range(0, spawnPoints.Length);

                int chance = Random.Range(0, 11);

                if (chance <= 9)
                    PoolManager.instance.ReuseObject(enemy, spawnPoints[spawnPointIndex].position, enemy.transform.rotation);
                else
                    PoolManager.instance.ReuseObject(enemy2, spawnPoints[spawnPointIndex].position, Quaternion.Euler(0, 0, 90));
            }
        }
    }

    void SpawnEnemies(int numberOfEnemies, int spawnPoint, int movement)
    {

    }

}