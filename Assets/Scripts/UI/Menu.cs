using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button btPlay;
    [SerializeField] private Button btSetting;

    [SerializeField] private Button btQuit;
    [SerializeField] private GameObject obSetting;
    void Start()
    {
        if (btPlay != null)
            btPlay.onClick.AddListener(PlayGame);
        if (btQuit != null)
            btQuit.onClick.AddListener(() => { Application.Quit(); });

        if (btSetting != null)
            btSetting.onClick.AddListener(() => { if (obSetting != null) obSetting.SetActive(true); });
    }
    private void PlayGame()
    {
        if (PlayerPrefs.HasKey("sceneToLoad"))
        {
            Debug.Log("123");
            SceneManager.LoadScene(PlayerPrefs.GetString("sceneToLoad"));

        }
        else
            SceneManager.LoadScene("Scene1-level1");
    }
}
