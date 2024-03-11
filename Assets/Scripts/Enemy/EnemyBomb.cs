using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour, IEnemy
{
	[SerializeField] private GameObject bomb;

	private Animator myAnimator;
	private SpriteRenderer spriteRenderer;

	readonly int ATTACK_HASH = Animator.StringToHash("attack");

	private void Awake()
	{
		myAnimator = GetComponent<Animator>();
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	public void Attack()
	{
		myAnimator.SetTrigger(ATTACK_HASH);

		if (transform.position.x - PlayerController.Instance.transform.position.x < 0)
		{
			spriteRenderer.flipX = false;
		}
		else
		{
			spriteRenderer.flipX = true;
		}
	}

	public void SpawnProjectileAnimEvent()
	{
		Instantiate(bomb, transform.position, Quaternion.identity);
	}
}
