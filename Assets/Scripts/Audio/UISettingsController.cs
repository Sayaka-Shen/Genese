using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Slider musicSlider;
    public Slider MusicSlider
    {
        get { return musicSlider; }
    }

    [SerializeField] private Slider sfxSlider;
    public Slider SFXSlider
    {
        get { return sfxSlider; }
    }

    private void Start()
    {
        musicSlider.value = AudioManager.Instance.MusicSource.volume;
        sfxSlider.value = AudioManager.Instance.SFXSource.volume;
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(sfxSlider.value);
    }
}
