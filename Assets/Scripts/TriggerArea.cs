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
		var visualSize = new Vector3(trigger.size.x*transform.lossyScale.x, trigger.size.y*transform.lossyScale.y, 0.2f);
		Gizmos.DrawCube(transform.position, visualSize);
	}
}
