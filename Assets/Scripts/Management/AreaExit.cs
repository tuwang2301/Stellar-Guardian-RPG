using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    [SerializeField] GameObject enemies;

    private float waitToLoadTime = 6f;

    private void Update()
    {
        if (enemies.transform.childCount == 0)
        {
            MessageController.Instance.ShowMessage("ENEMY CLEAR",100f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (enemies.transform.childCount == 0)
            {
                if (collision.gameObject.GetComponent<PlayerController>())
                {
                    SceneManagement.Instance.SetTransitionName(sceneTransitionName);
                    UIFade.Instance.FadeToBlack();
                    StartCoroutine(LoadSceneRoutine());
                }
            }
            else
            {
                MessageController.Instance.ShowMessage("You have to kill all the enemies to unlock this door",2f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            MessageController.Instance.ShowMessage("Try Press F",1f);
        }
    }

    private IEnumerator LoadSceneRoutine()
    {
        while (waitToLoadTime >= 0)
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}