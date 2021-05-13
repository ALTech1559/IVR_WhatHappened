using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class SecondCharacterTaker : MonoBehaviour, IPointerClickHandler, TakerInterface
{
    [SerializeField] private GameObject TexrmuxButton;

    private void Start()
    {
        //if the key is 1
        if (PlayerPrefs.GetInt("Termux") == 1)
        {
            SwitchOnTermuxButton();
        }
    }

    public void OnClickEvent()
    {
        //set key
        PlayerPrefs.SetInt("Termux", 1);
        SwitchOnTermuxButton();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent();
    }

    private void SwitchOnTermuxButton()
    {
        //activate object
        TexrmuxButton.SetActive(true);
    }
}
