using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChatManager : MonoBehaviour {
	
	public LineRenderer lineRenderer;
	public Text text;

	public static ChatManager instance;

	bool displaying=false;

	GameObject lineTarget;

	void Start () {
		instance = this;
		transform.localScale = Vector3.zero;
		instance.lineRenderer.enabled = false;
	}
	
	void Update () {
		if (lineTarget != null)
		{
			instance.lineRenderer.SetPosition(0, Camera.main.transform.position + Vector3.up * Camera.main.orthographicSize * 0.5f + Vector3.forward);
			var targetPos = lineTarget.transform.position - Vector3.forward + Vector3.up*0.75f;
			targetPos = new Vector3(targetPos.x, targetPos.y, Camera.main.transform.position.z + 1);
			instance.lineRenderer.SetPosition(1, targetPos);
		}
		else {
			instance.lineRenderer.SetPosition(0, Camera.main.transform.position + Vector3.up * Camera.main.orthographicSize * 0.5f + Vector3.forward);
			instance.lineRenderer.SetPosition(1, Camera.main.transform.position + Vector3.up * Camera.main.orthographicSize * 0.5f + Vector3.forward);
		}
	}

	public static void DisplayMessage(string message, GameObject owner)
	{
		var sequence = DOTween.Sequence();
		if (instance.displaying) { sequence.Append(HideMessage()); }
		sequence.AppendCallback(()=> { instance.lineTarget = owner; instance.text.text = message; });
		sequence.Append(instance.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack));
		instance.displaying = true;
		instance.lineRenderer.enabled = true;
	}

	public static Tweener HideMessage()
	{
		instance.lineTarget = null;
		instance.displaying = false;
		instance.lineRenderer.enabled = false;
		return instance.transform.DOScale(0, 0.3f).SetEase(Ease.OutExpo);
	}
}
