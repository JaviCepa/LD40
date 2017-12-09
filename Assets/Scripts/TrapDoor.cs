using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrapDoor : MonoBehaviour {

	bool folded=true;
	private Transform jointTransform;

	public float fallTime=1.5f;

	private void Start()
	{
		jointTransform = transform.parent;
	}

	void OnDamage(int amount) {
		if (folded)
		{
			jointTransform.DORotate(Vector3.zero, fallTime).SetEase(Ease.OutBounce);
			folded = false;
		}
	}
	
}
