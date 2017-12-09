using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TreasureTextManager : MonoBehaviour {
	
	public Text text;

	public static TreasureTextManager instance;
	
	void Start () {
		instance = this;
		transform.localScale = Vector3.zero;
	}

	public static void DisplayMessage(string message)
	{
		var sequence = DOTween.Sequence();
		sequence.AppendCallback(()=> { instance.text.text = message; });
		sequence.Append(instance.transform.DOScale(1, 0.8f).SetEase(Ease.OutBack));
		sequence.Append(instance.transform.DOScale(0, 0.3f).SetEase(Ease.OutExpo).SetDelay(3));
	}
}
