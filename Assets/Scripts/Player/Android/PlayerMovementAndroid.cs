using UnityEngine;
using System.Collections;

public class PlayerMovementAndroid : MonoBehaviour
{
#if UNITY_ANDROID
    public float speed = 300.0f;
    float accelStartY;
    float accelStartX;
    float x;
    float y;

    public GameObject afterburnerStandard;
    public GameObject afterburnerForward;
    public GameObject afterburnerBackwards;

    private ParticleSystem standard;
    private ParticleSystem forward;
    private ParticleSystem backwards;

    
    void Start () {
        accelStartX = Input.acceleration.x;
        accelStartY = Input.acceleration.y;

        standard = afterburnerStandard.GetComponent<ParticleSystem>();
        forward = afterburnerForward.GetComponent<ParticleSystem>();
        backwards = afterburnerBackwards.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {


        x = Input.acceleration.x - accelStartX;
        y = Input.acceleration.y - accelStartY;

        Vector2 direction = new Vector2(x, y);

        if (direction.sqrMagnitude > 1)
            direction.Normalize();

        Move(direction);

        
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x - 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y - 0.285f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;

        if (x < 0f)
        {
            standard.Stop();
            forward.Stop();
            backwards.Play();
        }
        else if (x > 0f)
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
    }
#endif

}