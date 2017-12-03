using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateContinuously : MonoBehaviour {

	public float rotationSpeed=10;
	
	void Update () {
		transform.localEulerAngles += Vector3.forward * rotationSpeed;
	}
}
