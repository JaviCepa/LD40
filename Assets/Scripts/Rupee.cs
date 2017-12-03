using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rupee : MonoBehaviour {

	public bool picked = false;

	private void Start()
	{
		picked = false;
	}

	void Bag (Bag container) {
		if (!picked)
		{
			picked = true;
			var target = FindObjectOfType<Lonk>();
			var sequence = DOTween.Sequence();
			sequence.Append(transform.DOMove(transform.position+Vector3.up, 0.25f).SetEase(Ease.OutExpo));
			sequence.Join(transform.DOScale(1.5f, 0.25f).SetEase(Ease.OutExpo));
			sequence.Append(transform.DOScaleX(0, 0.25f));
			sequence.AppendCallback(() => target.AddRupee());
			sequence.AppendCallback(() => container.currentAmount++);
			sequence.AppendCallback(() => Destroy(gameObject));
		}
	}
}
