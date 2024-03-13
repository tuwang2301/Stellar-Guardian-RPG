using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject obPause;
    private bool isShow = false;
    // Start is called before the first frame update
    void Start()
    {
        SetActvie(isShow);
       
        DontDestroyOnLoad(gameObject);
    }
    private void SetActvie(bool isActive)
    {
        if (obPause != null)
            obPause.SetActive(isActive);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isShow = !isShow;
            if (isShow == true)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
            SetActvie(isShow);

        }
    }
}
