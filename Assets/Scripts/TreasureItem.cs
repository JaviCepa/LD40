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

	public GameObject itemCollectedParticlesPrefab;

	private void Start()
	{
		startPosition = transform.position;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Hero picker = collision.gameObject.GetComponent<Hero>();

		if (picker != null && !picked) {
			picked = true;
			GetComponent<Collider2D>().enabled = false;
			picker.PickTreasure(gameObject, skill, nameToDisplay);
			Invoke("DisplayParticles", 1f);
		}
	}

	void DisplayParticles() {
		Instantiate(itemCollectedParticlesPrefab, transform.position - Vector3.forward, Quaternion.identity, transform);
	}

	private void Update()
	{
		if (!picked)
		{
			transform.position = startPosition + Vector3.up * amplitude * Mathf.Sin(Time.time * floatSpeed);
		}
	}
}
