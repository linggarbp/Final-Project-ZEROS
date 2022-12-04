using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    [SerializeField] DataStorage dataStorage;
    [SerializeField] Button continueButton;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        dataStorage.dataTimeline = PlayerPrefs.GetInt("Timeline");
        if (PlayerPrefs.GetInt("Timeline") == 0)
            continueButton.interactable = false;
    }

    [ContextMenu("ResetTimeLine")]
    public void ClickNewGame()
    {
        PlayerPrefs.SetInt("Timeline", 0);
        dataStorage.dataTimeline = 0;
        SceneManager.LoadScene("StoryMode1");
    }

    public void ClickContinue()
    {
        SceneManager.LoadScene("StoryMode1");
    }

    public void Quit()
    {
        Application.Quit();
    }

    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] AudioMixer audioMixer;
    private void Update()
    {
        audioMixer.SetFloat("Mixer_Master", LinearToDecibel(masterSlider.value));
        audioMixer.SetFloat("Mixer_BGM", LinearToDecibel(musicSlider.value));
        audioMixer.SetFloat("Mixer_SFX", LinearToDecibel(sfxSlider.value));

        if (PlayerPrefs.GetFloat("MasterVolume") != masterSlider.value)
            PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        if (PlayerPrefs.GetFloat("MusicVolume") != musicSlider.value)
            PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        if (PlayerPrefs.GetFloat("SFXVolume") != sfxSlider.value)
            PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);

    }
    private float LinearToDecibel(float linear)
    {
        // linear = linear < 0.0001f?0.0001f:linear;
        linear = Mathf.Clamp(linear, 0.0001f, 1);
        return 20 * Mathf.Log10(linear);
    }

}
