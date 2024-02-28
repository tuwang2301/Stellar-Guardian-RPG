using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private KnockBack knockBack;

    private void Awake()
    {
        knockBack = GetComponent<KnockBack>();
        rb = GetComponent<Rigidbody2D>();   
    }

    private void FixedUpdate()
    {
        if(knockBack.gettingKnockedBack) { return; }
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.deltaTime));
    }

    public void MoveTo(Vector2 pos)
    {
        moveDir = pos;
    }

    public void StopMoving()
    {
        moveDir = Vector3.zero;
    }
}
