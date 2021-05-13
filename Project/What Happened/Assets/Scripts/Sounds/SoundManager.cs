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
        ChangeSoundValue("MasterValue", "Master", masterSlider);
    }

    public void EffectsSlider()
    {
        ChangeSoundValue("EffectsValue", "Effects", effectsSlider);
    }

    public void BackGroundSlider()
    {
        ChangeSoundValue("BackgroundValue", "Background", backgroundSlider);
    }

    public void UISlider()
    {
        ChangeSoundValue("UIValue", "UI", uISlider);
    }

    private void ChangeSoundValue(string playerPrefsKey, string audioMixedGroup, Slider slider)
    {
        PlayerPrefs.SetFloat(playerPrefsKey, slider.value);
        Mixer.audioMixer.SetFloat(audioMixedGroup, Mathf.Lerp(-30, 20, slider.value));
    }
}
