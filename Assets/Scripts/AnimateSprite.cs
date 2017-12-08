using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSprite : MonoBehaviour {

	public Sprite frame1;
	public Sprite frame2;

	public float speed;

	SpriteRenderer sr;

	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		var odd=Mathf.RoundToInt(Time.time*speed)%2==0;
		sr.sprite = odd ? frame1 : frame2;
	}
}
