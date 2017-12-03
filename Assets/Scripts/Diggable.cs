using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diggable : MonoBehaviour {
	
	void Dig() {
		Destroy(gameObject);
	}
}
