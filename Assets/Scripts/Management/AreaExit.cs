using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    [SerializeField] GameObject enemies;

    private float waitToLoadTime = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (enemies.transform.childCount == 0)
        {
            if (other.gameObject.GetComponent<PlayerController>())
            {
                SceneManagement.Instance.SetTransitionName(sceneTransitionName);
                UIFade.Instance.FadeToBlack();
                StartCoroutine(LoadSceneRoutine());
            }
        }
        else
        {
            Debug.Log("You have to kill all the enemies to unlock this door");
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