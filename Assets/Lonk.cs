using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lonk : MonoBehaviour {

	public float walkSpeed = 0.3f;
	Animator animator;
	
	void Awake () {
		animator = GetComponent<Animator>();
	}

	public void Stop()
	{
		animator.SetFloat("hspeed", 0);
	}

	public void MoveLeft()
	{
		transform.position += Vector3.left * Time.fixedDeltaTime * walkSpeed;
		transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
		animator.SetFloat("hspeed", walkSpeed);
	}

	public void MoveRight()
	{
		transform.position += Vector3.right * Time.fixedDeltaTime * walkSpeed;
		transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
		animator.SetFloat("hspeed", walkSpeed);
	}

}
