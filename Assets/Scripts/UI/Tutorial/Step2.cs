using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Step2 : MonoBehaviour
{
    public Action<int> callBackStep2;
    [SerializeField] private Button btNextStep;
    private void Awake()
    {
        if (btNextStep != null)
        {
            btNextStep.onClick.AddListener(() =>
            {
                callBackStep2?.Invoke(3);
                PlayerPrefs.SetInt("StepOnTutorial", 3);
                gameObject.SetActive(false);
            });
        }
    }
}
