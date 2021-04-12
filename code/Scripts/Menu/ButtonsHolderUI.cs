using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsHolderUI : MonoBehaviour
{
    [SerializeField] private AudioSource buttonClickSound;
    public void Play()
    {
        ClickSound();
        if (PlayerPrefs.GetInt("Win") == 1)
        {
            PlayerPrefs.DeleteAll();
        }
        if (PlayerPrefs.GetInt("OnTheStreet") == 1)
        {
            SceneManager.LoadScene("Street");
        }
        else
        {
            SceneLoading.ChangeScene("House");
        }

    }

    public void NewGame()
    {
        ClickSound();
        PlayerPrefs.DeleteAll();
        Play();
    }

    public void Exit()
    {
        ClickSound();
        Application.Quit();
    }

    private void ClickSound()
    {
        buttonClickSound.Play();
    }
}
