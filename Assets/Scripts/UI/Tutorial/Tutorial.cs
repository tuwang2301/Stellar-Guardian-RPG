using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private const string FirstTimePlay = "FirstTimePlay";
    private const string StepOnTutorial = "StepOnTutorial";
    [SerializeField] private GameObject obStep1;
    [SerializeField] private GameObject obStep2;
    [SerializeField] private GameObject obStep3;
    [SerializeField] private GameObject obEnemies;
    [SerializeField] private GameObject obItem;
    void Start()
    {
        Debug.Log(PlayerPrefs.HasKey(FirstTimePlay));
        Debug.Log(PlayerPrefs.HasKey(StepOnTutorial));
        if (!PlayerPrefs.HasKey(FirstTimePlay))
        {
            if (obStep1 != null)
                obStep1.SetActive(false);
            if (obStep2 != null)
                obStep2.SetActive(false);
            if (obStep3 != null)
                obStep3.SetActive(false);
            if (obItem != null)
                obItem.SetActive(false);
            if (obEnemies != null)
                obEnemies.SetActive(false);

            obStep1.GetComponent<Step1>().callBackStep1 += (data) => { Step(data); };
            obStep2.GetComponent<Step2>().callBackStep2 += (data) => { Step(data); };
            obStep3.GetComponent<Step3>().callBackStep3 += (data) => { OnDoneAllStep(); };
            int step;
            if (PlayerPrefs.HasKey(StepOnTutorial))
            {
                step = PlayerPrefs.GetInt(StepOnTutorial);
            }
            else
            {
                step = 1;
                PlayerPrefs.SetInt(StepOnTutorial, 1);
            }
            Step(step);
        }
        else
        {
            OnDoneAllStep();
        }
    }
    private void Step(int step)
    {
        switch (step)
        {
            case 1:
                if (obStep1 != null)
                    obStep1.SetActive(true);
                break;
            case 2:
                if (obStep2 != null)
                    obStep2.SetActive(true);
                if (obItem != null)
                    obItem.SetActive(true);
                break;
            case 3:
                if (obStep3 != null)
                    obStep3.SetActive(true);
                if (obEnemies != null)
                    obEnemies.SetActive(true);
                break;
        }
    }
    private void OnDoneAllStep()
    {
        Destroy(gameObject);
        if (!PlayerPrefs.HasKey(FirstTimePlay))
        {
            PlayerPrefs.SetString(FirstTimePlay, "");
        }
    }
}
