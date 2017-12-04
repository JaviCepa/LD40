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
			var save=DOTween.defaultEaseOvershootOrAmplitude;
			transform.DOScale(1, 0.3f).SetEase(Ease.OutBack).SetDelay(transform.GetSiblingIndex()*0.1f);
			transform.DOPunchRotation(Vector3.forward * 15, 2, 2, 1).SetLoops(-1).SetDelay(Random.value);
		}
	}
	
}
