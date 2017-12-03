using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {

	public int maxAmount=10;
	public int currentAmount=0;

	private void Update()
	{
		var hits = Physics2D.OverlapCircleAll(transform.position, 0.5f);
		foreach (var hit in hits)
		{
			hit.gameObject.SendMessage("Bag", this, SendMessageOptions.DontRequireReceiver);
		}
		transform.localScale = Vector3.one * GetBagSize();
	}

	float GetBagSize()
	{
		return Mathf.Lerp(0.5f, 2f, (float)currentAmount / (float)maxAmount);
	}
}
