using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RopeTaker : MonoBehaviour, IPointerClickHandler, TakerInterface
{
    [SerializeField] private GameObject Speech;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent();
    }

    public void OnClickEvent()
    {
        //set key
        PlayerPrefs.SetInt("Trap", 1);
        //activate object
        Speech.SetActive(true);
        Destroy(this.gameObject);
    }
}
