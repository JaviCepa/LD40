using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Cannon : MonoBehaviour {

	public GameObject lonkDummy;
	public ParticleSystem ps;
	public GameObject trail;
	public DOTweenPath path;

	bool fired=false;

	Vector3[] pathPoints;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<Lonk>() != null && !fired) {
			Fire(collision.gameObject);
		}
	}

	private void Fire(GameObject playerObject)
	{
		fired = true;
		pathPoints = path.wps.ToArray();
		lonkDummy.transform.position = playerObject.transform.position;
		lonkDummy.SetActive(true);
		playerObject.SetActive(false);
		var sequence = DOTween.Sequence();
		sequence.Append(lonkDummy.transform.DOMove(transform.position + Vector3.up * 0.5f + (Vector3.up + Vector3.right) * 0.75f, 0.5f).SetEase(Ease.OutQuad));
		sequence.Append(lonkDummy.transform.DOMove(transform.position + Vector3.up * 0.5f + Vector3.forward, 0.5f).SetEase(Ease.InQuad));
		sequence.Join(lonkDummy.transform.DOScale(0.5f, 0.5f));
		sequence.Append(gameObject.transform.DOScaleX(1.5f, 1.5f));
		sequence.Join(gameObject.transform.DOScaleY(1f / 1.5f, 1.5f));
		sequence.Append(gameObject.transform.DOScale(1f, 0.1f).SetEase(Ease.OutBack));
		sequence.AppendCallback(() => EmitParticles());
		sequence.AppendCallback(() => trail.SetActive(true));
		sequence.AppendCallback(() => { lonkDummy.transform.localScale = Vector3.one; });
		sequence.AppendCallback(() => FindObjectOfType<Com.LuisPedroFonseca.ProCamera2D.ProCamera2DShake>().Shake(0));
		//sequence.Append(lonkDummy.transform.DOPath(points, 5f).SetEase(Ease.OutExpo));
			sequence.AppendCallback(() => playerObject.SetActive(true));
			sequence.Append(playerObject.transform.DOPath(pathPoints, 5f).SetEase(Ease.OutQuad));
			sequence.Join(trail.transform.DOPath(pathPoints, 5f).SetEase(Ease.OutQuad));
			//sequence.Join(playerObject.transform.DORotate(Vector3.forward * 360, 0.5f).SetLoops(10, LoopType.Restart).SetRelative(true).SetEase(Ease.Linear));
		sequence.AppendCallback(() => playerObject.SetActive(true));
		//sequence.Join(lonkDummy.transform.DORotate(Vector3.forward * 360, 0.25f).SetLoops(10, LoopType.Restart).SetRelative(true).SetEase(Ease.Linear));
		//sequence.AppendCallback(() => playerObject.transform.localRotation = Quaternion.identity);
		sequence.AppendInterval(3f);
		sequence.AppendCallback(() => trail.SetActive(false));
		//sequence.Join(lonkDummy.transform.DOScale(0.05f, 5f).SetEase(Ease.OutExpo));
		//sequence.AppendCallback(() => FindObjectOfType<Com.LuisPedroFonseca.ProCamera2D.ProCamera2DTransitionsFX>().TransitionExit());
		//sequence.AppendInterval(0.5f);
		//sequence.AppendCallback(()=>UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay"));
	}

	private void EmitParticles()
	{
		ps.Emit(30);
		GetComponent<AudioSource>().Play();
	}
}
