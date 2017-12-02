using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	public Sprite[] cloudSprites; 
	
	void Start () {
		Randomize();
	}
	
	void Randomize() {
		GetComponent<SpriteRenderer>().sprite = cloudSprites[Random.Range(0, cloudSprites.Length)];
	}
}
