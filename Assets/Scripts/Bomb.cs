using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bomb : MonoBehaviour {

	public GameObject target;
	public GameObject particles;

	Hero hero;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (hero == null) { hero = FindObjectOfType<Hero>(); }
		if (hero.currentSkills.Contains(SkillTypes.Bomb))
		{
			hero.RemoveTreasure(SkillTypes.Bomb);
			transform.localScale = Vector3.zero;
			GetComponent<SpriteRenderer>().enabled = true;
			var sequence = DOTween.Sequence();
			sequence.Append(transform.DOScale(1.0f, 0.5f));
			sequence.Append(transform.DOScale(1.2f, 0.5f).SetLoops(5, LoopType.Yoyo));
			sequence.AppendCallback(()=> particles.SetActive(true));
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
