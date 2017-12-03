using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boomerang : MonoBehaviour {

	public float rotationSpeed=10;
	public float returnSpeed=0.1f;
	GameObject target;

	void Throw(GameObject launcher) {
		target = null;
		var forward = Vector3.right * Mathf.Sign(launcher.transform.localScale.x);
		transform.position = launcher.transform.position + 0.5f * forward;
		transform.SetParent(null);
		transform.DOMove(launcher.transform.position + forward * 4f, 1f).OnComplete(() => Return(launcher));
	}

	void Return(GameObject launcher) {
		target = launcher;
	}

	void Update () {
		transform.localEulerAngles += Vector3.forward * Time.fixedDeltaTime * rotationSpeed;
		if (target != null) {
			var error = target.transform.position-transform.position;
			transform.position += error.normalized * returnSpeed;
			if (error.magnitude < 0.5f) {
				FindObjectOfType<Lonk>().RecoverBoomerang();
			}
		}

		var impact = Physics2D.OverlapCircle(transform.position, 0.4f).gameObject;
		if (impact!=null) {
			impact.SendMessage("Damage", 1, SendMessageOptions.DontRequireReceiver);
		}
	}
}
