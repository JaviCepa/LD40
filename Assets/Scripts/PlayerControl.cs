using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	Lonk lonk;

	private void Awake()
	{
		lonk = GetComponent<Lonk>();
	}
	
	void Update () {
		ProcessInput(Input.GetKeyDown(KeyCode.Z), lonk.Jump);
		ProcessInput(Input.GetKeyDown(KeyCode.X), lonk.Attack);
		ProcessInput(Input.GetKey(KeyCode.LeftArrow), lonk.MoveLeft);
		ProcessInput(Input.GetKey(KeyCode.RightArrow), lonk.MoveRight);
		ProcessInput(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow), lonk.Stop);
	}

	void ProcessInput(bool condition, System.Action Effect) {
		if (condition) {
			Effect();
		}
	}

}
