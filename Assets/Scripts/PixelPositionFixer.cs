using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PixelPositionFixer : MonoBehaviour {
	
	void Update () {
		if (!Application.isPlaying)
		{
			transform.localPosition = new Vector3(
				Mathf.Round(transform.localPosition.x * 8f) / 8f,
				Mathf.Round(transform.localPosition.y * 8f) / 8f,
				transform.localPosition.z
			);
		}
	}
}
