using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lonk : MonoBehaviour {

	public float walkSpeed = 0.3f;
	public float fallSpeed = 1f;
	Animator animator;
	
	void Awake () {
		animator = GetComponent<Animator>();
	}

	private void FixedUpdate()
	{
		TryMove(Vector3.down,
			() => { transform.position += Vector3.down * Time.fixedDeltaTime * fallSpeed; }
		);
	}

	public void Stop()
	{
		animator.SetFloat("hspeed", 0);
	}

	public void MoveLeft()
	{
		TryMove(Vector3.left, () =>
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
		TryMove(Vector3.right, () =>
		{
			transform.position += Vector3.right * Time.fixedDeltaTime * walkSpeed;
			transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
			animator.SetFloat("hspeed", walkSpeed);
		},
		Stop
		);
	}

	void TryMove(Vector3 direction, System.Action Action, System.Action Unable = null)
	{
		var perpendicular = new Vector3(direction.y, -direction.x);
		var forwardPoint = transform.position + direction * 0.5f;
		var topPoint = forwardPoint + perpendicular * 0.45f;
		var bottomPoint = forwardPoint - perpendicular * 0.45f;

		if (!Physics2D.Linecast(topPoint, bottomPoint))
		{
			Action();
			Debug.DrawLine(topPoint, bottomPoint, Color.yellow);
		}
		else
		{
			if (Unable!=null)
			{
				Unable();
			}
			Debug.DrawLine(topPoint, bottomPoint, Color.red);
		}
	}

}
