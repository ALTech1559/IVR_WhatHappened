using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] private GameObject MainLight;
    [SerializeField] private GameObject LanternLight;
    [SerializeField] private GameObject PhoneButton;
    [SerializeField] private GameObject KillersNote;

    [SerializeField] private AudioSource lightSound;
    [SerializeField] internal static bool lightInHouse = true;
    private void OnEnable()
    {
        ButtonsHolder.lightStatementChange += SwitchOffLight;
    }
    private void OnDisable()
    {
        ButtonsHolder.lightStatementChange -= SwitchOffLight;
    }
    private void SwitchOffLight() => StartCoroutine(SwitchOffLightCoroutine());
    
    private IEnumerator SwitchOffLightCoroutine()
    {

        yield return new WaitForSeconds(5);
        lightSound.Play();
        StartCoroutine(LightChange(false, 1));
        lightInHouse = false;
        yield return new WaitForSeconds(30);
        StartCoroutine(LightChange(true, 0));
        lightInHouse = true;
        PhoneButton.SetActive(false);
        KillersNote.SetActive(true);
        lightSound.Stop();
    }

    private IEnumerator LightChange(bool status, int lanternPause)
    {
        MainLight.SetActive(status);
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.1f);
            MainLight.SetActive(!status);
            yield return new WaitForSeconds(0.1f);
            MainLight.SetActive(status);
        }
        yield return new WaitForSeconds(lanternPause);
        LanternLight.SetActive(!status);
    }
}
