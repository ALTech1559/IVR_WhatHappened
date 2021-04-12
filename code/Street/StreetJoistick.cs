using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StreetJoistick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image Bg;
    private Image main;
    private Vector2 inputVector;

    private void Start()
    {
        Bg = GetComponent<Image>();
        main = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(Bg.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / 2 / Bg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / 2 / Bg.rectTransform.sizeDelta.y);

            inputVector = new Vector2(pos.x, pos.y);
            inputVector = (inputVector.magnitude > 0.1f) ? inputVector.normalized : inputVector;
            main.rectTransform.anchoredPosition = new Vector2(inputVector.x * (Bg.rectTransform.sizeDelta.x / 2), inputVector.y * (Bg.rectTransform.sizeDelta.y / 2));
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        main.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public float Horizontal()
    {
        if (inputVector.x != 0) return inputVector.x;
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.y != 0) return inputVector.y;
        else return Input.GetAxis("Vertical");
    }
}
