using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour {


	public AudioClip swimSound;
	public AudioClip footstepsSound;

	AudioSource audioSource;
	Hero hero;

	private bool underWater;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		hero = GetComponentInParent<Hero>();
	}

	public void PlayFootstep()
	{
		if (hero.isSwimming)
		{
			audioSource.clip = swimSound;
			audioSource.pitch = 1.2f + Random.Range(-0.2f, 0.2f);
			audioSource.Play();
		}
		else
		{
			audioSource.clip = footstepsSound;
			audioSource.pitch = 1.5f + Random.Range(-0.1f, 0.1f);
			audioSource.Play();
		}
	}
}
