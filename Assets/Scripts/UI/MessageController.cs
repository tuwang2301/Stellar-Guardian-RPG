using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : Singleton<MessageController>
{
    [SerializeField] TextMeshProUGUI messageText;

    protected override void Awake()
    {
        base.Awake();
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
