using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToShopScript : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    [SerializeField] private GameObject obj;
    private float waitToLoadTime = 2f;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaaa");
        // Check if the collider is the box
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            MessageController.Instance.ShowMessage("Wanna Buy Something?\n [Press F]", 3f);
        }
    }
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



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
