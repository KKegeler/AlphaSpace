using UnityEngine;
using System.Collections;

// Der Bullet-Manager nimmt Bullet-Objekte an und lädt sie in den Pool. 

public class BulletManager : MonoBehaviour
{
    public GameObject prefab1;
    public int loadNumber1 = 10;
    public GameObject prefab2;
    public int loadNumber2 = 10;

    void Start()
    {
        if (!prefab1)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        PoolManager.instance.CreatePool(prefab1, loadNumber1);
        PoolManager.instance.CreatePool(prefab2, loadNumber2);
    }
}