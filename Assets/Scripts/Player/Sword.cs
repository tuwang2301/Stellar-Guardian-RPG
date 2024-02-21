using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private Transform weaponCollider;

    private PlayerControls playerControls;
    private Animator animator;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerControls = new PlayerControls();
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Start()
    {
        playerControls.Combat.Attack.started += _ => Attack();
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        weaponCollider.gameObject.SetActive(true);
    }

    public void DoneAttacking()
    {
        weaponCollider.gameObject.SetActive(false);
    }

    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        if (mousePos.x > playerScreenPoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, 0);
            weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
            weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }


}
