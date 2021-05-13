using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class BatteryTaker : MonoBehaviour, IPointerClickHandler, TakerInterface
{
    internal static event UnityAction _onClick;
    public void OnClickEvent()
    {
        if (PlayerPrefs.GetInt("Lantern") == 1)
        {
            PlayerPrefs.SetInt("Battery", 1);
            //play animation
            GetComponent<Animator>().Play("BatteryAwake");
            StartCoroutine(Destroy());
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent();
    }

    private IEnumerator Destroy()
    {
        //invoke event
        _onClick?.Invoke();
        //wait for time
        yield return new WaitForSeconds(2);
        //destoy object
        Destroy(this.gameObject);
    }
}
