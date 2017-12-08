using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HookRenderer : MonoBehaviour {

	LineRenderer lineRenderer;
	Hero owner;

	bool clinged=false;
	private Vector3 clingPosition;

	void Awake() {
		lineRenderer = GetComponent<LineRenderer>();
		owner = FindObjectOfType<Hero>();
	}

	public void Cling() {
		clinged = true;
		clingPosition = transform.position;
	}

	public void Uncling()
	{
		clinged = false;
	}

	void LateUpdate () {
		if (owner == null || lineRenderer==null) { Awake(); }
		if (!clinged)
		{
			lineRenderer.SetPosition(0, transform.position);
		}
		else {
			lineRenderer.SetPosition(0, clingPosition);
			transform.position = clingPosition;
		}
		lineRenderer.SetPosition(1, owner.transform.position);
	}
}
