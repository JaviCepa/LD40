using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureItem : MonoBehaviour {

	public SkillTypes skill = SkillTypes.None;

	public float amplitude = 0.05f;
	public float floatSpeed = 1f;
	[Multiline]
	public string nameToDisplay="";

	Vector3 startPosition;
	bool picked=false;

	private void Start()
	{
		startPosition = transform.position;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		Lonk picker = collision.gameObject.GetComponent<Lonk>();

		if (picker != null && !picked) {
			picked = true;
			GetComponent<Collider2D>().enabled = false;
			picker.PickTreasure(gameObject, skill, nameToDisplay);
		}
	}

	private void Update()
	{
		if (!picked)
		{
			transform.position = startPosition + Vector3.up * amplitude * Mathf.Sin(Time.time * floatSpeed);
		}
	}
}
