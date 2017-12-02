using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureItem : MonoBehaviour {

	public SkillTypes skill = SkillTypes.None;

	private void OnTriggerStay2D(Collider2D collision)
	{
		Lonk picker = collision.gameObject.GetComponent<Lonk>();
		Debug.Log("Trigger "+ picker.verticalSpeed);
		if (picker != null) {
			GetComponent<Collider2D>().enabled = false;
			picker.PickTreasure(gameObject, skill);
			Debug.Log("TriggerPick");
		}
	}
}
