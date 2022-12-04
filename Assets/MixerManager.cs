using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField, Range(0, 1f)] float volumeMaster = 1;
    [SerializeField, Range(0, 1f)] float volumeBGM = 1;
    [SerializeField, Range(0, 1f)] float volumeSFX = 1;
    private void Update()
    {
        audioMixer.SetFloat("Mixer_Master", LinearToDecibel(volumeMaster));
        audioMixer.SetFloat("Mixer_BGM", LinearToDecibel(volumeBGM));
        audioMixer.SetFloat("Mixer_SFX", LinearToDecibel(volumeSFX));
    }
    private float LinearToDecibel(float linear)
    {
        // linear = linear < 0.0001f?0.0001f:linear;
        linear = Mathf.Clamp(linear, 0.0001f, 1);
        return 20 * Mathf.Log10(linear);
    }
}
