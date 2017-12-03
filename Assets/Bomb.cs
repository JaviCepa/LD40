using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bomb : MonoBehaviour {

	public GameObject target;

	Lonk lonk;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (lonk == null) { lonk = FindObjectOfType<Lonk>(); }
		if (lonk.currentSkills.Contains(SkillTypes.Bomb))
		{
			transform.localScale = Vector3.zero;
			GetComponent<SpriteRenderer>().enabled = true;
			var sequence = DOTween.Sequence();
			sequence.Append(transform.DOScale(1.0f, 0.5f));
			sequence.Append(transform.DOScale(1.2f, 0.5f).SetLoops(5, LoopType.Yoyo));
			//TODO: Particles
			sequence.AppendCallback(() => { Destroy(target); Destroy(gameObject); });
		}
	}

	private void OnDrawGizmos()
	{
		if (target) {
			Gizmos.DrawLine(target.transform.position, transform.position);
		}
	}

}
