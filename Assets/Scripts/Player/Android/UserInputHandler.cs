using UnityEngine;
using System.Collections;

public class UserInputHandler : MonoBehaviour {

    public delegate void AccelerometerChangedAction(Vector3 acceleration);
    public static event AccelerometerChangedAction OnAccelerometerChanged;

    private Vector3 defaultAcceleration;

    void OnEnable()
    {
        defaultAcceleration = new Vector3(Input.acceleration.x, Input.acceleration.y, -1 * Input.acceleration.z);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (OnAccelerometerChanged != null)
        {
            Vector3 acceleration = new Vector3(Input.acceleration.x, Input.acceleration.y, -1 * Input.acceleration.z);
            acceleration -= defaultAcceleration;
            OnAccelerometerChanged(acceleration);
        }
    }
}
