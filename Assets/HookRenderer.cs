using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HookRenderer : MonoBehaviour {

	LineRenderer lineRenderer;
	Lonk lonk;

	bool clinged=false;
	private Vector3 clingPosition;

	void Awake() {
		lineRenderer = GetComponent<LineRenderer>();
		lonk = FindObjectOfType<Lonk>();
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
		if (lonk==null || lineRenderer==null) { Awake(); }
		if (!clinged)
		{
			lineRenderer.SetPosition(0, transform.position);
		}
		else {
			lineRenderer.SetPosition(0, clingPosition);
			transform.position = clingPosition;
		}
		lineRenderer.SetPosition(1, lonk.transform.position);
	}
}
