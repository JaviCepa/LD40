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
		ProcessInput(Input.GetKeyDown(KeyCode.DownArrow), lonk.Dig);
		ProcessInput(Input.GetKey(KeyCode.UpArrow), lonk.Shield);
		ProcessInput(!Input.GetKey(KeyCode.UpArrow), lonk.Unshield);
		ProcessInput(Input.GetKey(KeyCode.LeftArrow), lonk.MoveLeft);
		ProcessInput(Input.GetKey(KeyCode.RightArrow), lonk.MoveRight);
		ProcessInput(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow), lonk.Stop);

		//ProcessInput(Input.GetAxisRaw("Jump") > 0, lonk.Jump);
		//ProcessInput(Input.GetAxisRaw("Fire1") > 0, lonk.Attack);
		//ProcessInput(Input.GetAxisRaw("Vertical") < 0, lonk.Dig);
		//ProcessInput(Input.GetAxisRaw("Vertical") > 0, lonk.Shield);
		//ProcessInput(Input.GetAxisRaw("Vertical") <= 0, lonk.Unshield);
		//ProcessInput(Input.GetAxisRaw("Horizontal") < 0, lonk.MoveLeft);
		//ProcessInput(Input.GetAxisRaw("Horizontal") > 0, lonk.MoveRight);
		//ProcessInput(Input.GetAxisRaw("Horizontal") == 0, lonk.Stop);
	}

	void ProcessInput(bool condition, System.Action Effect) {
		if (condition) {
			Effect();
		}
	}

}
