using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PictureCrash : MonoBehaviour, IPointerClickHandler
{
    private bool flag = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(flag == false)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 45), Time.deltaTime * 50);
            flag = true;
        }
    }
}
