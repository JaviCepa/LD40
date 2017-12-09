using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDependency : MonoBehaviour {

	public GameObject target;
	
	void Update ()
	{
		gameObject.SetActive(target.activeSelf);
	}
}
