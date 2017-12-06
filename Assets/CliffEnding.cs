using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffEnding : MonoBehaviour {

	bool open=false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!open)
		{
			open = true;
			LoadEnding();
		}
	}

	void LoadEnding()
	{
		GameManager.LoadEnding(EndingTypes.Cliff);
	}
}
