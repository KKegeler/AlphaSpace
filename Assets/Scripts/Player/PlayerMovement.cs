using UnityEngine;
using System.Collections;

// Bewegung des Spielers. ClampMagnitude wird aufgerufen, um zu verhindern
// dass sich der Spieler diagonal schneller bewegt als normal.

public class PlayerMovement : MonoBehaviour
{
#if UNITY_STANDALONE
    private Rigidbody2D rb;
    private Transform tr;

    public GameObject afterburnerStandard;
    public GameObject afterburnerForward;
    public GameObject afterburnerBackwards;

    private ParticleSystem standard;
    private ParticleSystem forward;
    private ParticleSystem backwards;

    public float speedX, speedY;
    public float maxSpeed = 300.0f;
    public float start = 150.0f;
    public float acc = 5.0f;
    private float x;
    private float y;
    private bool wasRight, wasLeft, wasUp, wasDown;
    
    

    void Start()
    {
        standard = afterburnerStandard.GetComponent<ParticleSystem>();
        forward = afterburnerForward.GetComponent<ParticleSystem>();
        backwards = afterburnerBackwards.GetComponent<ParticleSystem>();

        speedX = speedY = start;
        wasRight = wasLeft = wasUp = wasDown = false;
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();

        if (!rb || !tr || !standard || !forward || !backwards)
            Debug.LogError("Objekt im " + gameObject.name + " nicht gefunden!");
    }
    
    // Input
	void FixedUpdate ()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        bool right = false, left = false;
        bool up = false, down = false;

        if (inputX < 0)
        {
            standard.Stop();
            forward.Stop();
            backwards.Play();
        }
        else if (inputX > 0)
        {
            standard.Stop();
            forward.Play();
            backwards.Stop();
        }
        else
        {
            standard.Play();
            forward.Stop();
            backwards.Stop();
        }

        // SpeedDelay X
        if (inputX != 0)
        { 
            speedX = SpeedDelay(speedX);
            if (inputX > 0)
                right = true;
            else
            {
                left = true;
                
            }
        }
        else
            speedX = start;

        // SpeedDelay Y
        if (inputY != 0)
        {
            speedY = SpeedDelay(speedY);
            if (inputX > 0)
            {
                up = true;
                tr.rotation = Quaternion.Euler(15.0f, 0.0f, 270.0f);
            }
            else
            {
                down = true;
                tr.rotation = Quaternion.Euler(-15.0f, 0.0f, 270.0f);
            }
        }
        else
        {
            speedY = start;
            tr.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);
        }

        // Bei neuer Richtung Speed zurücksetzen
        if (wasDown == up || wasUp == down)
            speedY = start;
        if (wasRight == left || wasLeft == right)
            speedX = start;

        // Werte zuweisen
        x = (speedX * inputX * Time.deltaTime);
        y = (speedY * inputY * Time.deltaTime);
        Vector2 v2 = new Vector2(x, y);
        rb.velocity = Vector2.ClampMagnitude(v2, Mathf.Max(speedX, speedY) * Time.deltaTime);

        wasLeft = left;
        wasRight = right;
        wasUp = up;
        wasDown = down;

        
    }

    // SpeedDelay
    private float SpeedDelay(float speed)
    {
        if (speed < maxSpeed)
            speed += acc;
        else
            speed = maxSpeed;

        return speed;
    }
#endif

}