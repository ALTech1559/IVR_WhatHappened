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
        PlayerPrefsMechanic.ChangeValuse("Trap", 1);
        Speech.SetActive(true);
        Destroy(this.gameObject);
    }
}
