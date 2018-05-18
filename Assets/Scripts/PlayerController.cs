using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    public float speed = 5.0f;
    Rigidbody2D rigid;
    Vector2 velocity = new Vector2();

    void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        velocity.x = Input.GetAxis("Horizontal") * speed;
        velocity.y = Input.GetAxis("Vertical") * speed;
        rigid.velocity = velocity;


    }

}
