using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour {

	Vector3 initialAcceleration, currentAccelerationT,currentAccelerationR;
	float smooth = 0.4f;
	float newRotationX,newRotationZ;
	float sensitivity = 6;
	Rigidbody rb;

	public bool useForceMethod;
	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		initialAcceleration = Input.acceleration;
		currentAccelerationT = Vector3.zero;
	}

	void Update()
	{
		currentAccelerationT = Input.acceleration;
		Debug.DrawRay (transform.position + Vector3.up * 5f, currentAccelerationT * 10f, Color.red);
		if(useForceMethod)
		{
			if(rb!=null)
				rb.AddForce (currentAccelerationT.x*10f, 0, currentAccelerationT.y*10f);
		}
		else
		{
			transform.Translate (currentAccelerationT.x, 0, currentAccelerationT.y);
		}


	}
}
