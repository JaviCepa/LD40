using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsEndTrigger : MonoBehaviour {

	bool open=false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!open && FindObjectOfType<Hero>().airMovement.maxJumpHeight <= 0.8f)
		{
			open = true;
			Invoke("LoadEnding", 5);
		}
	}

	void LoadEnding()
	{
		GameManager.LoadEnding(EndingTypes.Stairs);
	}
}
