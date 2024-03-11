using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
	[SerializeField] private float duration = 1f;
	[SerializeField] private AnimationCurve animCurve;
	[SerializeField] private float heightY = 3f;
	[SerializeField] private GameObject bombProjectileShadow;
	[SerializeField] private GameObject splatterPrefab;

	private void Start()
	{
		GameObject bombShadow =
		Instantiate(bombProjectileShadow, transform.position + new Vector3(0, -0.3f, 0), Quaternion.identity);
		Vector3 playerPos = PlayerController.Instance.transform.position;
		Vector3 bombShadowStartPosition = bombShadow.transform.position;
		StartCoroutine(ProjectileCurveRoutine(transform.position, playerPos));
		StartCoroutine(MoveBombShadowRoutine(bombShadow, bombShadowStartPosition, playerPos));
	}

	private IEnumerator ProjectileCurveRoutine(Vector3 startPosition, Vector3 endPosition)
	{
		float timePassed = 0f;

		while (timePassed < duration)
		{
			timePassed += Time.deltaTime;
			float linearT = timePassed / duration;
			float heightT = animCurve.Evaluate(linearT);
			float height = Mathf.Lerp(0f, heightY, heightT);

			transform.position = Vector2.Lerp(startPosition, endPosition, linearT) + new Vector2(0f, height);

			yield return null;
		}
		Instantiate(splatterPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	private IEnumerator MoveBombShadowRoutine(GameObject bombShadow, Vector3 startPosition, Vector3 endPosition)
	{
		float timePassed = 0f;

		while (timePassed < duration)
		{
			timePassed += Time.deltaTime;
			float linearT = timePassed / duration;
			bombShadow.transform.position = Vector2.Lerp(startPosition, endPosition, linearT);
			yield return null;
		}

		Destroy(bombShadow);
	}
}
