using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicArea : MonoBehaviour {

	AudioSource source;

	void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<Hero>() != null)
		{
			source.Play();
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<Hero>() != null)
		{
			source.Stop();
		}
	}

}
