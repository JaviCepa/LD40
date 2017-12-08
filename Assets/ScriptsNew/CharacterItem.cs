using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItem : MonoBehaviour {
	
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
		col2D = GetComponent<Collider2D>();
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

	public void Use()
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
			col2D.enabled = true;
			idleSprite.enabled = false;
			activeSprite.enabled = true;
			inUse = true;
			OnUse();
		}
	}

	public void Withdraw()
	{
		if (inUse)
		{
			owner.character.InputEnabled = true;
			col2D.enabled = true;
			idleSprite.enabled = true;
			activeSprite.enabled = false;
			inUse = false;
			OnWithdraw();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		collision.SendMessage("Damage", 1, SendMessageOptions.DontRequireReceiver);
	}

	protected virtual void OnUse() { }
	protected virtual void OnWithdraw() { }

}
