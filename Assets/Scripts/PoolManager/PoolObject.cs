using UnityEngine;
using System.Collections;

// Basis-Klasse für Pool-Objekte

public class PoolObject : MonoBehaviour
{
    public virtual void OnObjectReuse() {}
}