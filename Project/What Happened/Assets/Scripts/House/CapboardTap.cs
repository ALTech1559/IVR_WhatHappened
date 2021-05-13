using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CapboardTap : MonoBehaviour, IPointerClickHandler
{
    public static event UnityAction _onClick; 
    public void OnPointerClick(PointerEventData eventData)
    {
        // activate event
        _onClick.Invoke();
    }
}
