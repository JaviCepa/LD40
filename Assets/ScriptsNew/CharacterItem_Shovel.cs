﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterItem_Shovel : CharacterItem
{

	bool digging = false;

	override protected void OnUse(Object data)
	{
		if (!digging)
		{
			digging = true;
			var startPos = activeSprite.transform.localPosition;
			var sequence = DOTween.Sequence();
			sequence.Append(activeSprite.transform.DOLocalMoveY(1f / 8f, actionDuration).SetLoops(1, LoopType.Restart).SetEase(Ease.InOutSine));
			sequence.AppendCallback(() => activeSprite.transform.localPosition = startPos);
			sequence.AppendCallback(() => DigGround());
			sequence.AppendCallback(() => digging = false);
		}
	}

	void DigGround()
	{
		var hits = Physics2D.OverlapCircleAll(transform.position + Vector3.down, 0.1f);

		foreach (var hit in hits)
		{
			hit.SendMessage("Dig", SendMessageOptions.DontRequireReceiver);
		}
	}
}