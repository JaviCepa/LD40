using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlatformerPro;
using DG.Tweening;

public class Hero : MonoBehaviour
{

	[HideInInspector]public Character character;
	Animator animator;
	public List<SkillTypes> currentSkills;

	GroundMovement_Digital groundMovement;
	AirMovement_Variable airMovement;
	BasicAttacks basicAttacks;

	private Vector3 lastCheckPoint;

	internal bool isSwimming;

	CharacterItem activeItem;

	private void Awake()
	{
		character = GetComponent<Character>();
		animator = GetComponentInChildren<Animator>();
		groundMovement = GetComponentInChildren<GroundMovement_Digital>();
		airMovement = GetComponentInChildren<AirMovement_Variable>();
	}

	private void Update()
	{
		if (character.Input.RunButton == ButtonState.DOWN) {
			Attack();
		}
	}

	internal void PickTreasure(GameObject treasure, SkillTypes skillType, string nameToDisplay = "")
	{
		Debug.Log("Pick treasure " + skillType.ToString());
		character.InputEnabled = false;
		var sequence = DOTween.Sequence();
		sequence.AppendCallback(() => character.ForceAnimation(PlatformerPro.AnimationState.PICKUP, 2f));
		sequence.Append(treasure.transform.DOMove(transform.position + Vector3.up * 1f, 1f).SetEase(Ease.OutQuad));
		sequence.AppendCallback(() => { if (nameToDisplay != "") { TreasureTextManager.DisplayMessage(nameToDisplay); } });
		sequence.AppendInterval(1.0f);
		sequence.Append(treasure.transform.DOMove(transform.position + Vector3.forward * 0.5f, 0.5f).SetEase(Ease.InQuad));
		sequence.AppendCallback(() => ActivateSkill(skillType));
		sequence.AppendCallback(() => character.InputEnabled = true);
		sequence.AppendCallback(() => Destroy(treasure));
	}
	
	private void ActivateSkill(SkillTypes skillType)
	{
		currentSkills.Add(skillType);
		MakeItemAvailable(skillType);
		groundMovement.speed -= 0.2f;
		airMovement.maxJumpHeight -= 0.5f;
		airMovement.minJumpHeight = Mathf.Max(airMovement.maxJumpHeight - 2f, 0);
	}
	
	private void MakeItemAvailable(SkillTypes skillType)
	{
		foreach (var characterItem in GetComponentsInChildren<CharacterItem>())
		{
			if (skillType.ToString() == characterItem.gameObject.name)
			{
				characterItem.MakeAvailable();
			}
		}
	}

	public void SaveCheckPoint()
	{
		lastCheckPoint = transform.position;
	}

	public void Kill()
	{
		character.ForceAnimation(PlatformerPro.AnimationState.DEATH, 2f);
		transform.position = lastCheckPoint;
	}

	CharacterItem UseItem(SkillTypes skillType)
	{
		foreach (var characterItem in GetComponentsInChildren<CharacterItem>())
		{
			if (characterItem.gameObject.name == skillType.ToString())
			{
				characterItem.Use();
				return characterItem;
			}
		}
		return null;
	}

	void WithdrawItem(SkillTypes skillType)
	{
		foreach (var characterItem in GetComponentsInChildren<CharacterItem>())
		{
			if (characterItem.gameObject.name == skillType.ToString())
			{
				characterItem.Withdraw();
			}
		}
	}

	public void Shield()
	{
		if (currentSkills.Contains(SkillTypes.Shield))
		{
			UseItem(SkillTypes.Shield);
		}
	}

	public void Unshield()
	{
		if (currentSkills.Contains(SkillTypes.Shield))
		{
			WithdrawItem(SkillTypes.Shield);
		}
	}


	public void Attack()
	{
		if (currentSkills.Contains(SkillTypes.Boomerang))
		{
			if (IsHookSurfaceAvailable() != null)
			{
				UseItem(SkillTypes.Hook);
				return;
			}
		}

		if (currentSkills.Contains(SkillTypes.Boomerang))
		{
			if (!character.Grounded)
			{
				UseItem(SkillTypes.Boomerang);
				return;
			}
		}

		if (currentSkills.Contains(SkillTypes.Sword))
		{
			UseItem(SkillTypes.Sword);
			return;
		}
	}

	private HookSurface IsHookSurfaceAvailable()
	{
		HookSurface hookHit = null;
		float hookLength = 7;
		var hit = Physics2D.Raycast(transform.position, Vector3.up, hookLength, character.layerMask.value).collider;
		if (hit)
		{
			hookHit = hit.gameObject.GetComponent<HookSurface>();
		}
		return hookHit;
	}

}
