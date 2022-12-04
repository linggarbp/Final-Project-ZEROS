using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    // [SerializeField, Range(0, 1f)] float volumeMaster = 1;
    // [SerializeField, Range(0, 1f)] float volumeBGM = 1;
    // [SerializeField, Range(0, 1f)] float volumeSFX = 1;


    private void Start()
    {
        audioMixer.SetFloat("Mixer_Master", PlayerPrefs.GetFloat("MasterVolume"));
        audioMixer.SetFloat("Mixer_BGM", PlayerPrefs.GetFloat("MusicVolume"));
        audioMixer.SetFloat("Mixer_SFX", PlayerPrefs.GetFloat("SFXVolume"));
    }


}
