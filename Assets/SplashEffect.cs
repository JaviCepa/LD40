using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffect : MonoBehaviour {

	public GameObject splashPrefab;

	public float height=1;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawLine(transform.position + Vector3.right + Vector3.up * height, transform.position + Vector3.left + Vector3.up * height);
	}

	private void OnTriggerEnter2D (Collider2D collision)
	{
		var position = collision.gameObject.transform.position;
		position = new Vector3(position.x, transform.position.y+height, position.z-1);
		Instantiate(splashPrefab, position, splashPrefab.transform.rotation);
	}
	
}
