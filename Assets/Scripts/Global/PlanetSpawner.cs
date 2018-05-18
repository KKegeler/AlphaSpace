using UnityEngine;
using System.Collections;

// Spawnt Planeten

public class PlanetSpawner : MonoBehaviour
{
    // Singleton
    static PlanetSpawner _instance;
    public static PlanetSpawner instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<PlanetSpawner>();

            return _instance;
        }
    }

    public Transform[] spawns;
    public GameObject[] prefabs;
    public int minWaitTime = 1;
    public int maxWaitTime = 11;
    int randomIndex1 = 0, prevRIndex1 = 0;
    int randomIndex2 = 0, prevRIndex2 = 0;
    int randomWaitTime = 0;
    [HideInInspector] public float randomZOffset = 0f;
    float prevRZOffset = 0f;
    float randomYOffset = 0f;

    private const int PRIM = 27;

    void Start()
    {
        if (spawns.Length < 1 || prefabs.Length < 1)
            Debug.LogError("Spawns im " + gameObject.name + " nicht vorhanden!");

        StartCoroutine("SpawnPlanets");
    }

    IEnumerator SpawnPlanets()
    {
        while (true)
        {
            randomIndex1 = Random.Range(0, prefabs.Length);
            randomIndex2 = Random.Range(0, spawns.Length);
            randomZOffset = Random.Range(0.5f, 1.2f);
            randomYOffset = Random.Range(0f, 0.3f);

            // Verhindert, dass 2 mal hintereinander entweder der gleiche Planet 
            // oder ein Planet an der selben Stelle spawnt oder den gleichen z-Wert hat
            if (randomIndex1 == prevRIndex1)
            {
                randomIndex1 += PRIM;
                randomIndex1 %= prefabs.Length;
            }

            if (randomIndex2 == prevRIndex2)
            {
                randomIndex2 += PRIM;
                randomIndex2 %= spawns.Length;
            }

            if(randomZOffset == prevRZOffset)
            {
                if (randomZOffset <= 0.1f)
                    randomZOffset += 0.2f;
                else
                    randomZOffset -= 0.1f;
            }

            PoolManager.instance.ReuseObject(prefabs[randomIndex1],
                    spawns[randomIndex2].position 
                    + new Vector3(3f, randomYOffset, 97f - randomZOffset), 
                    Quaternion.identity);

            prefabs[randomIndex1].gameObject.transform.localScale *= randomZOffset;

            prevRIndex1 = randomIndex1;
            prevRIndex2 = randomIndex2;
            prevRZOffset = randomZOffset;

            randomWaitTime = Random.Range(minWaitTime, maxWaitTime);

            yield return new WaitForSeconds(randomWaitTime);
        }
    }

}