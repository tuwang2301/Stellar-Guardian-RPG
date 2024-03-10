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

    public void Attack()
    {
        myAnimator.SetTrigger(FIRE_HASH);
        StartCoroutine(ShootArrows());
    }

    IEnumerator ShootArrows()
    {
        for (int i = 0; i < 3; i++)
        {
			AudioManager.Instance.PLaySFX("shoot");
			GameObject newArrow = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
            newArrow.GetComponent<Projectile>().UpdateProjectileRange(weaponInfo.weaponRange);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

}
