using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
	public Color areaColor = new Color(0, 1f, 0, 0.5f);

	BoxCollider2D trigger { get { if (trigger_ == null) { trigger_ = GetComponent<BoxCollider2D>(); } return trigger_; } }
	BoxCollider2D trigger_;

	private void OnDrawGizmos()
	{
		Gizmos.color = areaColor;
		var visualSize = new Vector3(trigger.size.x*transform.localScale.x, trigger.size.y*transform.localScale.y, 0.2f);
		Gizmos.DrawCube(transform.position, visualSize);
	}

	void OnDrawGizmosSelected()
	{
		transform.position = new Vector3(Mathf.Round(transform.position.x / 0.5f) * 0.5f, Mathf.Round(transform.position.y / 0.5f) * 0.5f, Mathf.Round(transform.position.z / 0.5f) * 0.5f);
		transform.localScale = new Vector3(Mathf.Round(transform.localScale.x / 0.5f) * 0.5f, Mathf.Round(transform.localScale.y / 0.5f) * 0.5f, Mathf.Round(transform.localScale.z / 0.5f) * 0.5f);
	}
}
