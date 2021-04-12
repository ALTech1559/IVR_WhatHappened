using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joistic : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private Image JB;
    [SerializeField] private Image J;
    private float move;
    private Vector2 inputVector;
    private Vector2 startpos;
    private bool statement = true;

    private void Start()
    {
        JB = GetComponent<Image>();
        J = transform.GetChild(0).GetComponent<Image>();
        startpos = new Vector2(J.rectTransform.anchoredPosition.x, J.rectTransform.anchoredPosition.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(JB.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / JB.rectTransform.sizeDelta.x);
            pos.y = (pos.y / JB.rectTransform.sizeDelta.y);
        }
        inputVector = new Vector2(pos.x * 2, pos.y * 2);
        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
        J.rectTransform.anchoredPosition = new Vector2(inputVector.x * (JB.rectTransform.sizeDelta.x / 2), inputVector.y * (JB.rectTransform.sizeDelta.y / 2));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        J.rectTransform.anchoredPosition = Vector2.zero;

    }


}
