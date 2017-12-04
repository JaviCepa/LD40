using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour {

	AudioSource source;

	bool playing=false;

	void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!playing)
		{
			playing = true;
			source.Play();
		}
	}
	
}
