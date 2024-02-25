using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;

    private void Update()
    {
        MoveProjectile();
    }

    public void MoveProjectile()
    {

        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);

    }
}
