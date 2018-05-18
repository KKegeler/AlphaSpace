using UnityEngine;
using System.Collections;

// Planeten werden nach links bewegt

public class PlanetObject : PoolObject
{
    public float planetSpeed;

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * planetSpeed);
    }

    public override void OnObjectReuse()
    {
        planetSpeed = Random.Range(0.3f, 0.5f);

        gameObject.transform.localScale = new Vector3(1, 1, 1);
        gameObject.transform.localScale *= PlanetSpawner.instance.randomZOffset;

        StartCoroutine("WaitForDestroy");
    }

    // Zerstört die Planeten nach einer gewissen Zeit
    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(90);

        gameObject.SetActive(false);
    }

}