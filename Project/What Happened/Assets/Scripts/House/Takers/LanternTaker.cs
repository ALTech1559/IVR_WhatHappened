using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;

public class LanternTaker : MonoBehaviour, IPointerClickHandler, TakerInterface
{
    private void Start()
    {
        //if the key is 1
        if (PlayerPrefsMechanic.GetValue("Lantern") == 1)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent();
    }

    public void OnClickEvent()
    {
        //set key
        PlayerPrefs.SetInt("Lantern", 1);
        //destroy object
        Destroy(this.gameObject);
    }
}
