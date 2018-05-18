using UnityEngine;
using System.Collections;

// Manager für die Planeten

public class PlanetsManager : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public int loadNumber = 3;

    void Start()
    {
        if (!prefab1 || !prefab2 || !prefab3 || !prefab4 || !prefab5 || !prefab6)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        PoolManager.instance.CreatePool(prefab1, loadNumber);
        PoolManager.instance.CreatePool(prefab2, loadNumber);
        PoolManager.instance.CreatePool(prefab3, loadNumber);
        PoolManager.instance.CreatePool(prefab4, loadNumber);
        PoolManager.instance.CreatePool(prefab5, loadNumber);
        PoolManager.instance.CreatePool(prefab6, loadNumber);
    }
}