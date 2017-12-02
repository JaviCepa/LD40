using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrapDoor : MonoBehaviour {

	bool folded=true;
	private Transform jointTransform;

	private void Start()
	{
		jointTransform = transform.parent;
	}

	void Damage(int amount) {
		if (folded)
		{
			jointTransform.DORotate(Vector3.zero, 1.5f).SetEase(Ease.OutBounce);
			folded = false;
		}
	}
	
}
