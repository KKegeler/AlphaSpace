using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    //public Vector2 speed = new Vector2(10, 10);
    //public Vector2 direction = new Vector2(-1, 0);
    public float speed;
    private Vector2 movement;
    Rigidbody2D bullet;
    //Rigidbody2D rigid = GetComponent<Rigidbody2D>();

    // Use this for initialization
    void Start () {
        bullet = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        //transform.TransformDirection(new Vector2(speed, 0));
        if (transform.position.x > 20)
        {
            Object.Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        bullet.AddForce(new Vector2(speed * 10, 0));
        movement = new Vector2(speed * 10, 0);
        bullet.velocity = transform.TransformDirection(movement);
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Entered Shooter Collision");
        if (col.gameObject.tag == "enemy")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
