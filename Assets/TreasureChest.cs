using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour {

	public Sprite openSprite;

	bool open=false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!open)
		{
			open = true;
			GetComponent<SpriteRenderer>().sprite = openSprite;
			GameManager.LoadEnding(EndingTypes.Treasure);
		}
	}
	
}
