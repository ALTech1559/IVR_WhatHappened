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
        if (PlayerPrefsMechanic.GetValue("Lantern") == 1)
        {
            PlayerPrefsMechanic.ChangeValuse("Battery", 1);
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
        _onClick?.Invoke();
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
