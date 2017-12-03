using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuOptions : MonoBehaviour {

	public Button playButton;
	public Button optionsButton;
	public Button exitButton;

	public CanvasGroup fader;

	void Start () {
		playButton.onClick.AddListener(()=>Play());
		optionsButton.onClick.AddListener(() => Options());
		exitButton.onClick.AddListener(() => Exit());
	}

	public void Play() {
		var sequence = DOTween.Sequence();
		sequence.Append(fader.DOFade(1, 0.5f));
		sequence.AppendCallback(() => UnityEngine.SceneManagement.SceneManager.LoadScene("Intro"));
	}

	public void Options() {

	}

	public void Exit()
	{
		Application.Quit();
	}
}
