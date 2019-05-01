using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Cannon : MonoBehaviour {

	public GameObject heroDummy;
	public ParticleSystem ps;
	public GameObject trail;
	public DOTweenPath path;

	bool fired=false;

	Vector3[] pathPoints;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Entered cannon");
		if (collision.gameObject.GetComponent<Hero>() != null && !fired)
		{
			Fire(collision.gameObject);
		}
	}

	private void Fire(GameObject playerObject)
	{
		fired = true;
		pathPoints = path.wps.ToArray();
		heroDummy.transform.position = playerObject.transform.position;
		heroDummy.SetActive(true);
		playerObject.SetActive(false);
		var sequence = DOTween.Sequence();
		sequence.AppendCallback(() => heroDummy.GetComponent<SpriteRenderer>().sortingOrder = 3);
		sequence.Append(heroDummy.transform.DOMove(transform.position + Vector3.up * 0.5f + (Vector3.up + Vector3.right) * 0.75f, 0.5f).SetEase(Ease.OutQuad));
		sequence.AppendCallback(() => heroDummy.GetComponent<SpriteRenderer>().sortingOrder = -3);
		sequence.Append(heroDummy.transform.DOMove(transform.position + Vector3.up * 0.5f + Vector3.forward, 0.5f).SetEase(Ease.InQuad));
		sequence.Join(heroDummy.transform.DOScale(0.5f, 0.5f));
		sequence.Append(gameObject.transform.DOScaleX(1.5f, 1.5f));
		sequence.Join(gameObject.transform.DOScaleY(1f / 1.5f, 1.5f));
		sequence.Append(gameObject.transform.DOScale(1f, 0.1f).SetEase(Ease.OutBack));
		sequence.AppendCallback(() => EmitParticles());
		sequence.AppendCallback(() => trail.SetActive(true));
		sequence.AppendCallback(() => { heroDummy.transform.localScale = Vector3.one; });
		sequence.AppendCallback(() => FindObjectOfType<Com.LuisPedroFonseca.ProCamera2D.ProCamera2DShake>().Shake(0));
		sequence.AppendCallback(() => playerObject.SetActive(true));
		sequence.Append(playerObject.transform.DOPath(pathPoints, 5f).SetEase(Ease.OutQuad));
		sequence.Join(trail.transform.DOPath(pathPoints, 5f, PathType.CatmullRom).SetEase(Ease.OutQuad));
		sequence.AppendCallback(() => playerObject.SetActive(true));
		sequence.AppendInterval(3f);
		sequence.AppendCallback(() => trail.SetActive(false));
	}

	private void EmitParticles()
	{
		ps.Emit(30);
		GetComponent<AudioSource>().Play();
	}
}
