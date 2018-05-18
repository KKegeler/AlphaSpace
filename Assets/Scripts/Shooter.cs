using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject kugel;
    Rigidbody2D bullet;
    public float geschossSpeed = 5.0f;
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    private Vector2 movement;
    public float fireRate = 1.0f;

    private float nextFire;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            bullet = Instantiate(kugel, transform.position, transform.rotation) as Rigidbody2D;
            //kugel = Instantiate(kugel, this.transform.position, this.transform.rotation);
            
        }
	}
    void FixedUpdate()
    {
        // Apply movement to the rigidbody

    }
}
