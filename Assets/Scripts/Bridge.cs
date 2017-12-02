using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bridge : MonoBehaviour {

	public Vector3 targetPosition;
	public Vector3 targetScale;
	public float deployTime=3;

	bool active=false;

	void Activate() {
		if (!active) {
			active = true;
			transform.DOMove(targetPosition, deployTime);
			transform.DOScale(targetScale, deployTime);
		}
	}
	
	[ContextMenu("SetTarget")]
	void SetTarget() {
		targetPosition = transform.position;
		targetScale = transform.localScale;
	}
}
