using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup Mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider effectsSlider;
    [SerializeField] private Slider backgroundSlider;
    [SerializeField] private Slider uISlider;
    void Start()
    {
        if (PlayerPrefs.HasKey("MasterValue") == false) PlayerPrefs.SetFloat("MasterValue", 0.5f);
        if (PlayerPrefs.HasKey("EffectsValue") == false) PlayerPrefs.SetFloat("EffectsValue", 0.5f);
        if (PlayerPrefs.HasKey("BackgroundValue") == false) PlayerPrefs.SetFloat("BackgroundValue", 0.5f);
        if (PlayerPrefs.HasKey("UIValue") == false) PlayerPrefs.SetFloat("UIValue", 0.5f);

        masterSlider.value = PlayerPrefs.GetFloat("MasterValue");
        effectsSlider.value = PlayerPrefs.GetFloat("EffectsValue");
        backgroundSlider.value = PlayerPrefs.GetFloat("BackgroundValue");
        uISlider.value = PlayerPrefs.GetFloat("UIValue");
    }
    public void MasterSlider()
    {
        PlayerPrefs.SetFloat("MasterValue", masterSlider.value);
        Mixer.audioMixer.SetFloat("Master",Mathf.Lerp(-80,20, masterSlider.value));
    }
    public void EffectsSlider()
    {
        PlayerPrefs.SetFloat("EffectsValue", effectsSlider.value);
        Mixer.audioMixer.SetFloat("Effects", Mathf.Lerp(-80, 20, effectsSlider.value));
    }
    public void BackGroundSlider()
    {
        PlayerPrefs.SetFloat("BackgroundValue", backgroundSlider.value);
        Mixer.audioMixer.SetFloat("Background", Mathf.Lerp(-80, 20, backgroundSlider.value));
    }
    public void UISlider()
    {
        PlayerPrefs.SetFloat("UIValue", uISlider.value);
        Mixer.audioMixer.SetFloat("UI", Mathf.Lerp(-80, 20, uISlider.value));
    }
}
