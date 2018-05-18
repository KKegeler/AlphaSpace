using UnityEngine;
using System.Collections;

// Der Enemy-Manager nimmt Enemy-Objekte an und lädt sie in den Pool. 

public class EnemyManager : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public int loadNumber = 5;

    void Start()
    {
        if (!prefab1 || !prefab2)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        PoolManager.instance.CreatePool(prefab1, loadNumber);
        PoolManager.instance.CreatePool(prefab2, loadNumber);
    }

}