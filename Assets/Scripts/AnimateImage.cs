using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateImage : MonoBehaviour {

	public Sprite frame1;
	public Sprite frame2;

	public float speed;

	Image image;

	void Start () {
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		var odd=Mathf.RoundToInt(Time.time*speed)%2==0;
		image.sprite = odd ? frame1 : frame2;
	}
}
