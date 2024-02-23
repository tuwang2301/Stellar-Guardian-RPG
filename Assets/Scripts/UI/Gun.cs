using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{

    private void Update()
    {
        MouseFollowWithOffset();
    }

    public void Attack()
    {
        Debug.Log("Gun Attack");
        ActiveWeapon.Instance.ToggleIsAttacking(false);
    }

    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

        float deltaY = mousePos.y - playerScreenPoint.y;
        float deltaX = mousePos.x - playerScreenPoint.x;

        float angle = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;

        if (deltaX > 0)
        {
            this.transform.rotation = Quaternion.Euler(0, -180, -angle);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, -(180 - angle));
        }
    }
}
