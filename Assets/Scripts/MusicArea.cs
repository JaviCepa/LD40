using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicArea : MonoBehaviour {

	AudioSource source;

	bool playing=false;

	void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log("Playing: "+source.clip.name);
		if (collision.gameObject.GetComponent<Lonk>() != null)
		{
			source.Play();
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		//Debug.Log("Stopping: " + source.clip.name);
		if (collision.gameObject.GetComponent<Lonk>() != null)
		{
			source.Stop();
		}
	}

}
