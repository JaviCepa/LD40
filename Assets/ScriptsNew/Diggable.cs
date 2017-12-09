using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Diggable : MonoBehaviour {
	
	void Dig() {
		var sequence=DOTween.Sequence();
		sequence.Append(transform.DOScale(0, 0.2f).SetEase(Ease.OutQuad));
		sequence.Join(transform.DORotate(Vector3.forward*90f, 0.2f).SetEase(Ease.OutQuad));
		sequence.AppendCallback(() => Destroy(gameObject));
	}
}
