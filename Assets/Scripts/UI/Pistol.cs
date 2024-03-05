using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
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

    public void Attack()
    {
        myAnimator.SetTrigger(FIRE_HASH);
        AudioManager.Instance.PLaySFX("shoot");
        GameObject newArrow = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
        newArrow.GetComponent<Projectile>().UpdateProjectileRange(weaponInfo.weaponRange);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
