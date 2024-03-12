using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button btPlay;
    [SerializeField] private Button btQuit;
    void Start()
    {
        if (btPlay != null)
            btPlay.onClick.AddListener(PlayGame);
    }
    private void PlayGame()
    {

        SceneManager.LoadScene("Scene1-level1");
    }
}
