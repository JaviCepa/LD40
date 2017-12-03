using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayChat : MonoBehaviour {

	[Multiline]
	public string textToDisplay="?";

	private void OnTriggerEnter2D(Collider2D collision)
	{
		ChatManager.DisplayMessage(textToDisplay, gameObject);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		ChatManager.HideMessage();
	}

}
