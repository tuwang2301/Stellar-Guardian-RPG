using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] private Button btClose;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSfx;


    private void Start()
    {
        if (btClose != null)
            btClose.onClick.AddListener(() => gameObject.SetActive(false));
        if (sliderMusic != null)
        {
            float VolumeMusic = 0;
            if (PlayerPrefs.HasKey("VolumeMusic"))
            {
                VolumeMusic = PlayerPrefs.GetFloat("VolumeMusic");
            }
            else
            {
                PlayerPrefs.SetFloat("VolumeMusic", AudioManager.Instance.musicSource.volume);
            }
            sliderMusic.value = PlayerPrefs.GetFloat("VolumeMusic");
            sliderMusic.onValueChanged.AddListener((data) => { OnMusicLenghtChange(); });

        }
        if (sliderSfx != null)
        {
            float VolumeSfx = 0;
            if (PlayerPrefs.HasKey("VolumeSfx"))
            {
                VolumeSfx = PlayerPrefs.GetFloat("VolumeSfx");
            }
            else
            {
                PlayerPrefs.SetFloat("VolumeSfx", AudioManager.Instance.sfxSource.volume);
            }
            sliderSfx.value = PlayerPrefs.GetFloat("VolumeSfx");
            sliderSfx.onValueChanged.AddListener((data) => { OnSfxLenghtChange(); });
        }
        gameObject.SetActive(false);

    }
    private void OnMusicLenghtChange()
    {
        AudioManager.Instance.musicSource.volume = sliderMusic.value;
        PlayerPrefs.SetFloat("VolumeMusic", sliderMusic.value);
    }
    private void OnSfxLenghtChange()
    {
        AudioManager.Instance.sfxSource.volume = sliderSfx.value;
        PlayerPrefs.SetFloat("VolumeSfx", sliderSfx.value);
    }
}
