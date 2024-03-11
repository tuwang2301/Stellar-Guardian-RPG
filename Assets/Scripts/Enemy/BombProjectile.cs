using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProjectile : MonoBehaviour
{
	[SerializeField] private float duration = 1f;
	[SerializeField] private AnimationCurve animCurve;
	[SerializeField] private float heightY = 3f;

	private void Start()
	{

		Vector3 playerPos = PlayerController.Instance.transform.position;

		StartCoroutine(ProjectileCurveRoutine(transform.position, playerPos));
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

		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
		playerHealth?.TakeDamage(1, transform);
	}
}
