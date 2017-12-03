using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Slashable : MonoBehaviour {

	public int health = 1;

	void Damage(int amount) {
		health -= amount;
		if (health <= 0) {
			var sequence = DOTween.Sequence();
			sequence.AppendCallback(()=>GetComponent<BoxCollider2D>().enabled=false);
			sequence.Append(transform.DOScale(0, 0.2f));
			sequence.AppendCallback(() => Destroy(gameObject));
		}
	}
}
