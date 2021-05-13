using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyTaker : MonoBehaviour, IPointerClickHandler, TakerInterface
{
    public void OnClickEvent()
    {
        //set key
        PlayerPrefsMechanic.ChangeValuse("CorridorKey", 1);
        //destroy object
        Destroy(this.gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent();
    }

    private void Start()
    {
        //if key is 1
        if (PlayerPrefs.GetInt("CorridorKey") == 1)
        {
            Destroy(this.gameObject);
        }
    }
}
