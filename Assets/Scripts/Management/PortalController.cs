using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : Singleton<PortalController>
{

    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;

    private float waitToLoadTime = 6f;

    protected override void Awake()
    {
        base.Awake();
        this.gameObject.SetActive(false);
    }

    public void ShowPortal()
    {
        this.gameObject.SetActive(true);
    }

    public void HidePortal()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F) && collision.gameObject.GetComponent<PlayerController>())
        {
            AudioManager.Instance.PLaySFX("scene");
            SceneManagement.Instance.SetTransitionName(sceneTransitionName);
            UIFade.Instance.FadeToBlack();
            StartCoroutine(LoadSceneRoutine());
        }
    }

    private IEnumerator LoadSceneRoutine()
    {
        while (waitToLoadTime >= 0)
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }

        if (sceneToLoad.Equals("Scene1-level2") || sceneToLoad.Equals("Scene1-level3"))
        {
            PlayerHealth.Instance.RESPAWN_SCENE = sceneToLoad;
        }
        PlayerPrefs.SetString("sceneToLoad", sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }

}
