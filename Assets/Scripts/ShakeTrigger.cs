using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTrigger : MonoBehaviour {

	Com.LuisPedroFonseca.ProCamera2D.ProCamera2DShake shake;

	public int presetIndex=0;

	void Awake()
	{
		shake = FindObjectOfType<Com.LuisPedroFonseca.ProCamera2D.ProCamera2DShake>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		shake.Shake(presetIndex);
	}
}
