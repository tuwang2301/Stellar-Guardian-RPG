using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destroyVFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageSource damageSource = other.gameObject.GetComponent<DamageSource>();
        Projectile projectile = other.gameObject.GetComponent<Projectile>();
        if (damageSource || projectile)
        {
            if(projectile && !projectile.isEnemyProjectile)
            {
				GetComponent<PickUpSpawner>().DropItems();
				Instantiate(destroyVFX, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}else if(damageSource)
            {
				GetComponent<PickUpSpawner>().DropItems();
				Instantiate(destroyVFX, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}     
        } 
    }
}
