using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionController : MonoBehaviour
{
    [SerializeField] private Button btnQuit;
    void Start()
    {
        if (btnQuit != null)
            btnQuit.onClick.AddListener(() => { this.gameObject.SetActive(false); });
    }

}
