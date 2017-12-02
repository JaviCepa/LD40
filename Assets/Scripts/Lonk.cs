using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lonk : MonoBehaviour {

	public float walkSpeed = 0.3f;
	public float fallSpeed = 1f;
	public int maxJumpSpeed = 50;
	public float gravity = 0.1f;
	public float colliderWidth = 0.35f;

	PlayerControl control;

	public float verticalSpeedLimit = 4;

	[HideInInspector]public float verticalSpeed = 0;
	Animator animator;
	public LayerMask layerMask;

	public ParticleSystem splashPs;

	public List<SkillTypes> currentSkills;

	void Splash() {
		splashPs.Emit(10);
	}

	void Awake ()
	{
		control = GetComponent<PlayerControl>();
		animator = GetComponent<Animator>();
		currentSkills = new List<SkillTypes>();
	}

	private void Update()
	{

		TryMove(Vector3.down * 1.1f,
			() => { grounded = false; },
			() => { grounded = true; },
			false);
		animator.SetBool("grounded", grounded);

		TryMove(Vector3.down,
			() => { },
			() => { if (verticalSpeed < 0) { verticalSpeed = 0; } }
		);
		
		TryMove(Vector3.up*Mathf.Sign(verticalSpeed),
			() => {
				transform.position += Vector3.up * verticalSpeed * Time.fixedDeltaTime;
				verticalSpeed -= gravity;
				if (verticalSpeed < verticalSpeedLimit) { verticalSpeed = verticalSpeedLimit; }
			},
			() => { verticalSpeed = 0; verticalSpeed -= gravity; }
		);
		

		animator.SetFloat("vspeed", verticalSpeed);
	}

	internal void PickTreasure(GameObject treasure, SkillTypes skill)
	{
		control.enabled = false;
		var sequence = DOTween.Sequence();
		sequence.AppendCallback(() => animator.SetBool("treasure", true));
		sequence.Append(treasure.transform.DOMove(transform.position + Vector3.up * 1.5f, 1f).SetEase(Ease.OutQuad));
		sequence.AppendInterval(1.0f);
		sequence.Append(treasure.transform.DOMove(transform.position + Vector3.forward * 0.5f, 0.5f).SetEase(Ease.InQuad));
		sequence.AppendCallback(() => animator.SetBool("treasure", false));
		sequence.AppendCallback(() => ActivateSkill(skill));
		sequence.AppendCallback(() => Destroy(treasure));
		sequence.AppendCallback(() => control.enabled = true);
		sequence.AppendCallback(() => FindAndActivateSkillObject(skill));
	}

	private void FindAndActivateSkillObject(SkillTypes skill)
	{
		foreach (Transform child in transform)
		{
			if (skill.ToString() == child.name) {
				child.gameObject.SetActive(true);
			}
		}
	}

	Vector3 lastCheckPoint;

	public void SaveCheckPoint() {
		lastCheckPoint = transform.position;
	}

	public void Kill() {
		transform.position = lastCheckPoint + Vector3.right*0.5f*Mathf.Sign(transform.localScale.x);
	}

	private void ActivateSkill(SkillTypes skillType)
	{
		currentSkills.Add(skillType);
	}

	public void Stop()
	{
		animator.SetFloat("hspeed", 0);
	}

	public GameObject swordOff;
	public GameObject swordOn;
	public GameObject boomerangOff;
	public GameObject boomerangOn;

	[HideInInspector]public bool grounded;

	public void Attack()
	{
		if (grounded || !currentSkills.Contains(SkillTypes.Boomerang))
		{
			if (currentSkills.Contains(SkillTypes.Sword) && swordOff.activeSelf == true)
			{
				swordOff.SetActive(false);
				swordOn.SetActive(true);

				var hits = Physics2D.OverlapCircleAll(transform.position + Vector3.right * transform.localScale.x, 0.25f);

				foreach (var hit in hits)
				{
					hit.SendMessage("Damage", 1, SendMessageOptions.DontRequireReceiver);
				}

				Invoke("ResetSword", 0.2f);
			}
		}
		else
		{
			if (currentSkills.Contains(SkillTypes.Boomerang) && boomerangOff.activeSelf == true) {
				boomerangOff.SetActive(false);
				boomerangOn.SetActive(true);
				boomerangOn.SendMessage("Throw", gameObject, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	void ResetSword() {
		swordOff.SetActive(true);
		swordOn.SetActive(false);
	}

	public void RecoverBoomerang()
	{
		boomerangOff.SetActive(true);
		boomerangOn.SetActive(false);
		boomerangOn.transform.SetParent(transform);
	}

	public void Jump()
	{
		bool overGround = false;

		TryMove(Vector3.down, () => { overGround = false; }, () => { overGround = true; }, false);
		
		if (overGround) {
			TryMove(Vector3.up, () =>
			{
				//transform.position += Vector3.up * Time.fixedDeltaTime * maxJumpSpeed;
				verticalSpeed = maxJumpSpeed;
				animator.SetFloat("hspeed", walkSpeed);
			},
			Stop
			);
		}
	}

	public void MoveLeft()
	{
		TryMove(Vector3.left * colliderWidth, () =>
		{
			transform.position += Vector3.left * Time.fixedDeltaTime * walkSpeed;
			transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
			animator.SetFloat("hspeed", walkSpeed);
		},
		Stop
		);
	}

	public void MoveRight()
	{
		TryMove(Vector3.right * colliderWidth, () =>
		{
			transform.position += Vector3.right * Time.fixedDeltaTime * walkSpeed;
			transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
			animator.SetFloat("hspeed", walkSpeed);
		},
		Stop
		);
	}

	void TryMove(Vector3 direction, System.Action Action, System.Action Unable = null, bool correctPosition = true)
	{
		var perpendicular = new Vector3(direction.y, -direction.x);
		var forwardPoint = transform.position + direction * 0.49f;
		var topPoint = forwardPoint + perpendicular * 0.25f;
		var bottomPoint = forwardPoint - perpendicular * 0.25f;

		if (!Physics2D.Linecast(topPoint, bottomPoint, layerMask.value))
		{
			Action();
			Debug.DrawLine(topPoint, bottomPoint, Color.yellow);
		}
		else
		{
			if (correctPosition) {
				RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1, layerMask.value);
				if (hit.distance != 0)
				{
					var error = ((Vector3)hit.point - transform.position) - direction * 0.49f;
					if (error.magnitude < 0.5f) {
						transform.position += error;
					}
				}
			}

			if (Unable!=null)
			{
				Unable();
			}
			Debug.DrawLine(topPoint, bottomPoint, Color.red);
		}
	}

}

public enum SkillTypes { None, Sword, Boomerang, Bomb, Shovel, Bag, Hook, Rod, Anvil, Gem }