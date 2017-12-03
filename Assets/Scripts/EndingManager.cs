using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Com.LuisPedroFonseca.ProCamera2D;

public class EndingManager : MonoBehaviour {

	[Multiline]
	public string endingText="?";

	public int endingIndex=1;

	public Text text;

	static int totalEndingCount=6;

	void Start () {
		Camera.main.gameObject.GetComponent<ProCamera2DTransitionsFX>().TransitionEnter();
		text.text = endingText;
	}


	void Update ()
	{
		float textSpeed=15f;
		int currentIndex=Mathf.Clamp(Mathf.CeilToInt(Time.timeSinceLevelLoad*textSpeed), 0, endingText.Length);

		text.text = endingText.Substring(0, currentIndex) +"<color=black>"+ endingText.Substring(currentIndex, endingText.Length - currentIndex) +"</color>"+"\n"+"<color=yellow>Game Over - "+"(Ending "+endingIndex+"/"+totalEndingCount+")"+"    Press ESCAPE to retry."+"</color>";

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		}
	}
}
