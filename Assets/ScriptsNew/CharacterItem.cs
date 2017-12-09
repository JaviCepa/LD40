using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItem : MonoBehaviour
{
	
	public bool removeControlWhileInUse = false;
	public float actionDuration = 0;
	AudioSource soundOnUse;

	protected Collider2D col2D;
	protected SpriteRenderer idleSprite;
	protected SpriteRenderer activeSprite;
	protected Hero owner;

	bool available;
	bool inUse;

	private void Awake()
	{
		owner = GetComponentInParent<Hero>();
		col2D = GetComponentInChildren<Collider2D>();
		idleSprite = GetComponent<SpriteRenderer>();
		soundOnUse = GetComponent<AudioSource>();
		if (transform.childCount > 0)
		{
			activeSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
		}
	}

	public void MakeAvailable()
	{
		available = true;
		Withdraw();
	}

	public void MakeUnavailable()
	{
		available = false;
		idleSprite.enabled = false;
		if (activeSprite!=null)
		{
			activeSprite.enabled = false;
		}
		inUse = false;
		if (col2D != null)
		{
			col2D.enabled = false;
		}
	}

	public void Use(UnityEngine.Object data = null)
	{
		if (available && !inUse)
		{
			if (removeControlWhileInUse)
			{
				owner.character.InputEnabled = false;
			}
			if (actionDuration > 0)
			{
				Invoke("Withdraw", actionDuration);
			}
			if (soundOnUse != null) {
				soundOnUse.Play();
			}
			if (col2D != null)
			{
				col2D.enabled = true;
			}
			idleSprite.enabled = false;
			activeSprite.enabled = true;
			inUse = true;
			OnUse(data);
		}
	}

	public void Withdraw()
	{
		if (col2D != null)
		{
			col2D.enabled = false;
		}
		owner.character.InputEnabled = true;
		idleSprite.enabled = true;
		activeSprite.enabled = false;
		inUse = false;
		OnWithdraw();
	}

	protected virtual void OnUse(UnityEngine.Object data) { }
	protected virtual void OnWithdraw() { }

}
