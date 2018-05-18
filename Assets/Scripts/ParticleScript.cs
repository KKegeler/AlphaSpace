using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

    private ParticleSystem ps;
   
    void Start ()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Play();
    }

    void Update()
    {
        if (!ps.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
