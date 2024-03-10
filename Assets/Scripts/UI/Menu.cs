using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button btPlay;
    [SerializeField] private Button btQuit;
    void Start()
    {
        if (btPlay != null)
            btPlay.onClick.AddListener(PlayGame);
        if (btQuit != null)
            btQuit.onClick.AddListener(() => { Application.Quit(); });
    }
    private void PlayGame()
    {

    }
}
