using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button btPlay;
    [SerializeField] private Button btnInstruction;
    [SerializeField] private GameObject Instruction;
    void Start()
    {
        if (btPlay != null)
            btPlay.onClick.AddListener(PlayGame);
        if (btnInstruction != null)
            btnInstruction.onClick.AddListener(() => { Instruction.SetActive(true); });
    }
    private void PlayGame()
    {
        SceneManager.LoadScene("Scene1-level1");
    }
}
