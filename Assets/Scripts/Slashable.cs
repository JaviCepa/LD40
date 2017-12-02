using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slashable : MonoBehaviour {

	public int health = 1;

	void Damage(int amount) {
		health -= amount;
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
