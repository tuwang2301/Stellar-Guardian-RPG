using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    public void Attack()
    {
        Debug.Log("Gun Attack");
        ActiveWeapon.Instance.ToggleIsAttacking(false);
    }
}
