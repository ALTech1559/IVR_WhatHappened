using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PictureHolder : MonoBehaviour, IPointerClickHandler
{
    private bool _isMoved = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isMoved == false)
        {
            //move game object on scene
            transform.Translate(4, 0, 0);
            //update flag
            _isMoved = true;
        }
    }
}
