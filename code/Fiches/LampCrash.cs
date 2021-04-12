using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LampCrash : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var _rigidbody = gameObject.AddComponent<Rigidbody>();
        _rigidbody.useGravity = true;
        Destroy(this.gameObject, 1.2f);
    }

}
