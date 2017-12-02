using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lonk : MonoBehaviour {

	public float walkSpeed = 0.3f;
	public float fallSpeed = 1f;
	public int maxJumpSpeed = 50;
	public float gravity = 0.1f;
	public float colliderWidth = 0.35f;
	public float verticalSpeedLimit = 4;

	float verticalSpeed = 0;
	Animator animator;
	public LayerMask layerMask;

	void Awake ()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{

		TryMove(Vector3.down * 1.1f,
			() => { animator.SetBool("grounded", false); },
			() => { animator.SetBool("grounded", true); },
			false);

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

	public void Stop()
	{
		animator.SetFloat("hspeed", 0);
	}

	public void Jump()
	{
		TryMove(Vector3.up, () =>
		{
			transform.position += Vector3.up * Time.fixedDeltaTime * maxJumpSpeed;
			verticalSpeed = maxJumpSpeed;
			animator.SetFloat("hspeed", walkSpeed);
		},
		Stop
		);
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
