using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;

	private void Awake()
	{
		instance = this;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		}
	}

	public static void LoadEnding(EndingTypes endingType) {
		PlayerPrefs.SetInt(endingType.ToString(), 1);

		Debug.Log("Loading ending: "+endingType.ToString());
		switch (endingType)
		{
			case EndingTypes.None:
				break;
			case EndingTypes.Anvil:
				instance.TransitionToEnding("AnvilEnding");
				break;
			case EndingTypes.Stairs:
				instance.TransitionToEnding("StairsEnding");
				break;
			case EndingTypes.Princess:
				instance.TransitionToEnding("PrincessEnding");
				break;
			case EndingTypes.Treasure:
				instance.TransitionToEnding("TreasureEnding");
				break;
			case EndingTypes.Fishing:
				instance.TransitionToEnding("FishingEnding");
				break;
			case EndingTypes.LavaPit:
				instance.TransitionToEnding("LavaEnding");
				break;
			case EndingTypes.Dragon:
				instance.TransitionToEnding("DragonEnding");
				break;
			case EndingTypes.Cliff:
				instance.TransitionToEnding("CliffEnding");
				break;
			case EndingTypes.PrincessWeapon:
				instance.TransitionToEnding("PrincessWeaponEnding");
				break;
			default:
				Debug.Log("Ending not defined");
				break;
		}
	}

	void TransitionToEnding(string endingName)
	{
		var sequence = DOTween.Sequence();
		sequence.AppendCallback(() => FindObjectOfType<Com.LuisPedroFonseca.ProCamera2D.ProCamera2DTransitionsFX>().TransitionExit());
		sequence.AppendInterval(1);
		sequence.AppendCallback(() => UnityEngine.SceneManagement.SceneManager.LoadScene(endingName));
	}

}


public enum EndingTypes { None, Anvil, Stairs, Princess, Dragon, Treasure, Fishing, LavaPit, Cliff, PrincessWeapon }