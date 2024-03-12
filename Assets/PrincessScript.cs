using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessScript : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F))
        {
            MessageController.Instance.HideMessage();

            if (collision.gameObject.GetComponent<PlayerController>())
            {
                obj.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaaa");
        // Check if the collider is the box
        if (collision.gameObject.GetComponent<PlayerController>())
        {
             MessageController.Instance.ShowMessage("I love you!", 3f);
        }
    }
}
