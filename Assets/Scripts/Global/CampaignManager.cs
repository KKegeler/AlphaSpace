using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CampaignManager : MonoBehaviour {

    public GameObject enemy;
    public GameObject boss;
    public Transform[] spawnPoints;
    public float waitWhileWave = 1;
    public float waitBetweenWaves = 5;
    public float waitBeforeBoss = 5;

    public int tempAt = 0;
    public int campaignAt = 0;
    private int spawnPointIndex;
    private int numberOfEnemiesInWave;

    // Use this for initialization
    void Start () {
        if (SceneManager.GetActiveScene().name == "Campaign")
        {
            StartCoroutine (spawnWaves());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnWaves()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            if (campaignAt == 0)
            {
                numberOfEnemiesInWave = 8;
                for (int i = 0; i < numberOfEnemiesInWave; i++)
                {
                    PoolManager.instance.ReuseObject(enemy, spawnPoints[0].position, enemy.transform.rotation);
                    yield return new WaitForSeconds(waitWhileWave);
                    if (i == numberOfEnemiesInWave - 1)
                        campaignAt = 1;
                }
                yield return new WaitForSeconds(waitBetweenWaves);
            }

            else if (campaignAt == 1)
            {
                numberOfEnemiesInWave = 16;
                for (int i = 0; i < numberOfEnemiesInWave; i++)
                {
                    tempAt = i % 2;
                    PoolManager.instance.ReuseObject(enemy, spawnPoints[tempAt*2].position, enemy.transform.rotation);
                    yield return new WaitForSeconds(waitWhileWave);
                    if (i == numberOfEnemiesInWave - 1)
                        campaignAt++;
                }
                yield return new WaitForSeconds(waitBetweenWaves);
            }

            else if (campaignAt == 2)
            {
                numberOfEnemiesInWave = 20;
                for (int i = 0; i < numberOfEnemiesInWave; i++)
                {
                    tempAt = i % 2;
                    PoolManager.instance.ReuseObject(enemy, spawnPoints[(tempAt+1)*2].position, enemy.transform.rotation);
                    yield return new WaitForSeconds(waitWhileWave);
                    if (i == numberOfEnemiesInWave - 1)
                        campaignAt++;
                }
                yield return new WaitForSeconds(waitBetweenWaves);
            }

            else if (campaignAt == 3)
            {
                waitWhileWave = .8f;
                numberOfEnemiesInWave = 30;
                for (int i = 0; i < numberOfEnemiesInWave; i++)
                {
                    tempAt = i % 3;
                    PoolManager.instance.ReuseObject(enemy, spawnPoints[tempAt*2].position, enemy.transform.rotation);
                    yield return new WaitForSeconds(waitWhileWave);
                    if (i == numberOfEnemiesInWave - 1)
                        campaignAt++;
                }
                yield return new WaitForSeconds(waitBetweenWaves);
                waitWhileWave = 1f;
            }

            else if (campaignAt == 4)
            {
                numberOfEnemiesInWave = 30;
                for (int i = 0; i < numberOfEnemiesInWave; i++)
                {
                    tempAt = i % 3;
                    PoolManager.instance.ReuseObject(enemy, spawnPoints[tempAt * 2].position, enemy.transform.rotation);
                    yield return new WaitForSeconds(waitWhileWave);
                    if (i == numberOfEnemiesInWave - 1)
                        campaignAt++;
                }
                yield return new WaitForSeconds(waitBetweenWaves);
            }

            else if (campaignAt == 5)
            {
                yield return new WaitForSeconds(waitBeforeBoss);

                boss.SetActive(true);

                yield return new WaitForSeconds(5);

                boss.GetComponent<BoxCollider2D>().enabled = true;
                
                yield return new WaitForSeconds(waitBetweenWaves);
            }
        }
    }
}
