using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FragileGround : MonoBehaviour {

	Hero hero;

	bool broken = false;
	
	void Start ()
	{
		hero = FindObjectOfType<Hero>();
	}
	
	void Update () {
		if (hero.currentSkills.Contains(SkillTypes.Anvil) && !broken)
		{
			broken = true;
			Collapse();
		}
	}

	private void Collapse()
	{
		GetComponent<BoxCollider2D>().enabled = false;
		var distance=5;
		var jumpHeight = Random.Range(0f, 5f);
		var jumpTime = Random.Range(0.5f, 1f);
		var sequence = DOTween.Sequence();
		sequence.AppendInterval((transform.position-hero.transform.position).magnitude/5f);
		sequence.Join(transform.DOMoveX(transform.position.x + Random.Range(-distance, distance), jumpTime*2));
		sequence.Join(transform.DOScale(0, jumpTime * 1.5f));
		sequence.Join(transform.DORotate(360 * Vector3.forward * Random.value, jumpTime * 2).SetEase(Ease.OutExpo));
		sequence.Join(transform.DOMoveY(transform.position.y + jumpHeight, jumpTime).SetEase(Ease.OutQuad));
		sequence.Join(transform.DOMoveY(transform.position.y - jumpHeight*Random.Range(0.5f,2f), jumpTime).SetEase(Ease.InQuad).SetDelay(jumpTime));
	}
}
