using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CharacterItem_Boomerang : CharacterItem
{

	public float rotationSpeed=10;
	public float returnSpeed=0.1f;

	GameObject boomerangProjectile;
	GameObject target;
	bool fired;

	private void Start()
	{
		boomerangProjectile = transform.GetChild(0).gameObject;
	}

	protected override void OnUse(UnityEngine.Object data)
	{
		Throw();
	}

	private void Throw()
	{
		fired = true;
		target = null;
		var forward = Vector3.right * Mathf.Sign(owner.transform.localScale.x);
		boomerangProjectile.transform.position = owner.transform.position + 0.5f * forward;
		boomerangProjectile.transform.SetParent(null);
		boomerangProjectile.transform.DOMove(owner.transform.position + forward * 4f, 1f).OnComplete(() => Return());
	}

	void Return()
	{
		target = owner.gameObject;
	}

	void Update()
	{
		if (fired)
		{
			boomerangProjectile.transform.localEulerAngles += Vector3.forward * Time.deltaTime * rotationSpeed;

			if (target != null)
			{
				var error = target.transform.position - boomerangProjectile.transform.position;
				boomerangProjectile.transform.position += error.normalized * returnSpeed;
				if (error.magnitude < 0.5f)
				{
					fired = false;
					Withdraw();
				}
			}

			var impactHits = Physics2D.OverlapCircleAll(boomerangProjectile.transform.position, 0.25f);
			foreach (var impactHit in impactHits)
			{
				if (impactHit != null)
				{
					var impact = impactHit.gameObject;
					if (impact != null)
					{
						impact.SendMessage("OnDamage", 1, SendMessageOptions.DontRequireReceiver);
					}
				}
			}
		}
	}

}
