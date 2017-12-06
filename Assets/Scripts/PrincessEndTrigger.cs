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
		Lonk lonk = FindObjectOfType<Lonk>();

		if (lonk.currentSkills.Contains(SkillTypes.Shield))
		{
			GameManager.LoadEnding(EndingTypes.PrincessWeapon);
		}
		else {
			GameManager.LoadEnding(EndingTypes.Princess); 
		}

	}
}
