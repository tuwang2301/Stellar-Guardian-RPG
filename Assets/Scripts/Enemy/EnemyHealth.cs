using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust = 10f;
    [SerializeField] public bool isBulletProof = false;
    [SerializeField] private Slider healthSlider;


    private int currentHealth;
    private KnockBack knockBack;
    private Flash flash;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
    }

    private void Start()
    {
        currentHealth = startingHealth;
        UpdateHealthSlider();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        AudioManager.Instance.PLaySFX("hit");
        knockBack.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
        UpdateHealthSlider();
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            GetComponent<PickUpSpawner>().DropItems();
            Destroy(gameObject);
        }
    }

    private void UpdateHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = startingHealth;
            healthSlider.value = currentHealth;
        }
    }
}
