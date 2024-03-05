using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageText;

    public static MessageController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(false);
    }

    public void ShowMessage(string text, float messageTime)
    {
        messageText.text = text;
        this.gameObject.SetActive(true);
        StartCoroutine(ShowDialog(messageTime));
    }

    public void HideMessage()
    {
        this.gameObject.SetActive(false);
    }

    private IEnumerator ShowDialog(float messageTime)
    {
        yield return new WaitForSeconds(messageTime);
        this.gameObject.SetActive(false);
    }
}
