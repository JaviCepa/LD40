using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public GameObject target;

	bool used = false;

	private void Start()
	{
		GetComponent<Collider2D>().isTrigger = true;
	}

	void OnDamage(int amount)
	{
		if (!used)
		{
			used = true;
			transform.localScale = new Vector3(transform.localScale.x*0.5f, transform.localScale.y, transform.localScale.z);
			target.SendMessage("Activate", target, SendMessageOptions.DontRequireReceiver);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		OnDamage(1);
	}

	private void OnDrawGizmos()
	{
		if (target != null)
        {
			Gizmos.DrawLine(transform.position, target.transform.position);
		}
	}

}
