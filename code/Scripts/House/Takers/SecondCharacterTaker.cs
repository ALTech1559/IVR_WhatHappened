using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SecondCharacterTaker : MonoBehaviour, IPointerClickHandler, TakerInterface
{
    [SerializeField] private GameObject TexrmuxButton;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Termux") == 1)
        {
            SwitchOnTermuxButton();
        }
    }

    public void OnClickEvent()
    {
        PlayerPrefs.SetInt("Termux", 1);
        SwitchOnTermuxButton();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent();
    }

    private void SwitchOnTermuxButton()
    {
        TexrmuxButton.SetActive(true);
    }
}
