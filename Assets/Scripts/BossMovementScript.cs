using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossMovementScript : MonoBehaviour {

    private Rigidbody2D r2D;

    private bool reachedDestination = true;

    private int campaignAt;
    private int tempAt;
    private Vector3[] path;
    private int currentPosition;

    //wall Boundaries
    float wall_left = -10.0f;
    float wall_right = 15.0f;
    float wall_top = 5.0f;
    float wall_bottom = -5.0f;

    //AI properties
    Vector2 AI_Position;
    public float Speed = 1.0f;
    private int i = 0;

    // Use this for initialization
    void Start () {
        r2D = GetComponent<Rigidbody2D>();

        if (r2D == null)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");

        path = new Vector3[3];
        path[0] = new Vector3(6f, 0f);
        path[1] = new Vector3(6f, 4f);
        path[2] = new Vector3(6f, -4f);

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(path[i], transform.position);
        transform.position = Vector2.MoveTowards(transform.position, path[i], Time.deltaTime * Speed);
        if (dist <= 0.2f && i <= 1)
            this.i++;
        if (dist <= 0.1f && i == 2)
            this.i--;
    }
}
