using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button btPlay;
    [SerializeField] private Button btSetting;
    [SerializeField] private Button BtnInstruction;
    [SerializeField] private Button btQuit;
    [SerializeField] private Button btnCloseInstruction;
    [SerializeField] private GameObject obSetting;
    [SerializeField] private GameObject instruction;

    void Start()
    {
        PlayerPrefs.DeleteAll();

        if (btPlay != null)
            btPlay.onClick.AddListener(PlayGame);
        if (btQuit != null)
            btQuit.onClick.AddListener(() => { Application.Quit(); });
        if (BtnInstruction != null)
            BtnInstruction.onClick.AddListener(() => { if (instruction != null) instruction.SetActive(true); });
        if (btnCloseInstruction != null)
            btnCloseInstruction.onClick.AddListener(() => { if (btnCloseInstruction != null) instruction.SetActive(false); });
        if (btSetting != null)
            btSetting.onClick.AddListener(() => { if (obSetting != null) obSetting.SetActive(true); });
    }
    private void PlayGame()
    {
        if (PlayerPrefs.HasKey("sceneToLoad"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("sceneToLoad"));

        }
        else
            SceneManager.LoadScene("Scene1-level1");
    }
}
