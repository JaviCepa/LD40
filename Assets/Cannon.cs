using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Cannon : MonoBehaviour {

	public GameObject lonkDummy;
	public ParticleSystem ps;
	public DOTweenPath path;

	Vector3[] points;

	private void Update()
	{
		var collider = Physics2D.OverlapCircle(transform.position+Vector3.up*0.5f, 0.45f);
		if (collider) {
			Attach(collider.gameObject);
		}
	}

	private void Attach(GameObject playerObject)
	{
		lonkDummy.transform.position = playerObject.transform.position;
		lonkDummy.SetActive(true);
		Destroy(playerObject);
		var sequence = DOTween.Sequence();
		sequence.Append(lonkDummy.transform.DOMove(transform.position + Vector3.up * 0.5f + (Vector3.up + Vector3.right) * 0.75f, 0.5f).SetEase(Ease.OutQuad));
		sequence.Append(lonkDummy.transform.DOMove(transform.position + Vector3.up * 0.5f + Vector3.forward, 0.5f).SetEase(Ease.InQuad));
		sequence.Join(lonkDummy.transform.DOScale(0.5f, 0.5f));
		sequence.Append(gameObject.transform.DOScaleX(1.5f, 1.5f));
		sequence.Join(gameObject.transform.DOScaleY(1f / 1.5f, 1.5f));
		sequence.Append(gameObject.transform.DOScale(1f, 0.1f).SetEase(Ease.OutBack));
		sequence.AppendCallback(() => EmitParticles());
		points = path.wps.ToArray();
		sequence.AppendCallback(() => { lonkDummy.transform.localScale = Vector3.one; });
		sequence.Append(lonkDummy.transform.DOPath(points, 5f).SetEase(Ease.OutExpo));
		sequence.Join(lonkDummy.transform.DORotate(Vector3.forward * 360, 0.25f).SetLoops(10, LoopType.Restart).SetRelative(true).SetEase(Ease.Linear));
		sequence.Join(lonkDummy.transform.DOScale(0.05f, 5f).SetEase(Ease.OutExpo));
		sequence.AppendCallback(()=>UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay"));
	}

	private void EmitParticles()
	{
		ps.Emit(30);
	}
}
