using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPitEndTrigger : MonoBehaviour {

	bool open=false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!open)
		{
			open = true;
			Invoke("LoadEnding", 6);
		}
	}

	void LoadEnding()
	{
		GameManager.LoadEnding(EndingTypes.LavaPit);
	}
}

