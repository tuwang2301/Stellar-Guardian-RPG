using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    readonly int FIRE_HASH = Animator.StringToHash("Fire");

    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }

    public void Attack()
    {
        myAnimator.SetTrigger(FIRE_HASH);
        Debug.Log(this.transform.rotation);
        GameObject newArrow = Instantiate(bulletPrefab, bulletSpawnPoint.position, this.transform.rotation);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
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
