using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SetVolume : MonoBehaviour
{

    [SerializeField] private TMP_Text volumeTextUI = null;
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        slider.value = 0.5f;
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }

    //// Update is called once per frame
    //void Update()
    //{
    //
    //}

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
    }

    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue)*20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

}
