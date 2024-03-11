using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Step3 : MonoBehaviour
{
    public Action<int> callBackStep3;
    [SerializeField] private Button btNextStep;
    private void Awake()
    {
        if (btNextStep != null)
            btNextStep.onClick.AddListener(() => { callBackStep3?.Invoke(4); });
    }
}
