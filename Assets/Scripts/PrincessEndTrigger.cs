using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessEndTrigger : MonoBehaviour {

	bool open=false;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!open)
		{
			open = true;
			Invoke("LoadEnding", 1);
		}
	}

	void LoadEnding()
	{
		Hero hero = FindObjectOfType<Hero>();

		if (hero.currentSkills.Contains(SkillTypes.Shield))
		{
			GameManager.LoadEnding(EndingTypes.PrincessNoEquipment);
		}
		else {
			GameManager.LoadEnding(EndingTypes.Princess); 
		}

	}
}
