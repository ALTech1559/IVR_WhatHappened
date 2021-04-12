using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyTaker : MonoBehaviour, IPointerClickHandler, TakerInterface
{
    public void OnClickEvent()
    {
        PlayerPrefsMechanic.ChangeValuse("CorridorKey", 1);
        Destroy(this.gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent();
    }

    private void Start()
    {
        if (PlayerPrefsMechanic.GetValue("CorridorKey") == 1)
        {
            Destroy(this.gameObject);
        }
    }
}
