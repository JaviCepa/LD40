﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDependency : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.SetActive(target.activeSelf);
	}
}