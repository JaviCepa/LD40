using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		Debug.Log("Loading ending: "+endingType.ToString());
		switch (endingType)
		{
			case EndingTypes.None:
				break;
			case EndingTypes.Anvil:
				break;
			case EndingTypes.Stairs:
				break;
			case EndingTypes.Princess:
				break;
			case EndingTypes.Dragon:
				break;
			case EndingTypes.Treasure:
				break;
			case EndingTypes.Fishing:
				break;
			case EndingTypes.LavaPit:
				break;
			default:
				Debug.Log("Ending not defined");
				break;
		}
	}

}


public enum EndingTypes { None, Anvil, Stairs, Princess, Dragon, Treasure, Fishing, LavaPit }