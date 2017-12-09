using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterItem_Hook : CharacterItem
{

	GameObject hookHead;

	LineRenderer lineRenderer;

	bool clinged=false;
	private Vector3 clingPosition;

	void Start()
	{
		lineRenderer = GetComponentInChildren<LineRenderer>();
		hookHead = activeSprite.gameObject;
	}

	void LateUpdate()
	{
		if (!clinged)
		{
			lineRenderer.SetPosition(0, hookHead.transform.position);
		}
		else
		{
			lineRenderer.SetPosition(0, clingPosition);
			hookHead.transform.position = clingPosition;
		}
		lineRenderer.SetPosition(1, owner.transform.position);
	}

	protected override void OnUse(Object data)
	{
		LaunchHook((HookSurface)data);
	}

	public void Cling()
	{
		clinged = true;
		clingPosition = hookHead.transform.position;
	}

	public void Uncling()
	{
		clinged = false;
	}

	private void LaunchHook(HookSurface hookSurface)
	{
		if (hookSurface != null)
		{
			hookHead.transform.position = transform.position;
			var sequence = DOTween.Sequence();
			sequence.Append(hookHead.transform.DOMoveY(hookSurface.transform.position.y - 0.5f, 0.3f * actionDuration).SetEase(Ease.Linear));
			sequence.AppendCallback(() => Cling());
			sequence.Append(owner.transform.DOMoveY(hookSurface.transform.position.y - 0.75f, 0.7f * actionDuration));
			sequence.AppendCallback(() => Uncling());
			sequence.AppendCallback(() => Withdraw());
		}
	}

}
