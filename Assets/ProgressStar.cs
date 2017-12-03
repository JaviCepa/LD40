using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProgressStar : MonoBehaviour {

	public EndingTypes ending;
	
	void Start () {
		if (PlayerPrefs.GetInt(ending.ToString()) == 1) {
			GetComponent<Image>().color = Color.white;
			transform.localScale = Vector3.zero;
			transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(transform.GetSiblingIndex()*0.25f);
		}
	}
	
}
