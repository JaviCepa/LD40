using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItem_Sword : CharacterItem {

	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.SendMessage("OnDamage", 1, SendMessageOptions.DontRequireReceiver);
	}

}
