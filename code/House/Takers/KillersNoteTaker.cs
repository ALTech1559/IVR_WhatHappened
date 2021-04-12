using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KillersNoteTaker : MonoBehaviour, IPointerClickHandler, TakerInterface
{

    [SerializeField] private GameObject KillersSpeech;

    public void OnClickEvent()
    {
        PlayerPrefsMechanic.ChangeValuse("AllowToStreet", 1);
        KillersSpeech.SetActive(true);
        Destroy(this.gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent();
    }

}
