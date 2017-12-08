using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {

	public int maxAmount=5;
	public int currentAmount=0;

	private void Update()
	{
		if (currentAmount < maxAmount)
		{
			var hits = Physics2D.OverlapCircleAll(transform.position, 0.5f);
			foreach (var hit in hits)
			{
				hit.gameObject.SendMessage("Bag", this, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	
}
