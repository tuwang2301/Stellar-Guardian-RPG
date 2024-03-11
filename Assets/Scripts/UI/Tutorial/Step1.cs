using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Step1 : MonoBehaviour
{
    public Action<int> callBackStep1;
    [SerializeField] private Image imgW;
    [SerializeField] private Image imgA;
    [SerializeField] private Image imgS;
    [SerializeField] private Image imgD;
    [SerializeField] private Image imgMouse;
    private bool isPressW;
    private bool isPressA;
    private bool isPressS;
    private bool isPressD;
    private bool isClickLeftMouse;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            isPressW = true;
            if (imgW != null)
                imgW.gameObject.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isPressA = true;
            if (imgA != null)
                imgA.gameObject.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isPressS = true;
            if (imgS != null)
                imgS.gameObject.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isPressD = true;
            if (imgD != null)
                imgD.gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClickLeftMouse = true;
            if (imgMouse != null)
                imgMouse.gameObject.SetActive(true);
        }
        if (isPressW && isPressA && isPressS && isPressD && isClickLeftMouse)
        {
            PlayerPrefs.SetInt("StepOnTutorial", 2);
            callBackStep1?.Invoke(2);
            gameObject.SetActive(false);
        }
    }
}
