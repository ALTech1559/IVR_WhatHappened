using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PressingButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Enter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Exit();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Enter();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Exit();
    }

    private void Enter()
    {
        _animator.Play("Enter");
    }

    private void Exit()
    {
        _animator.Play("Exit");
    }
}
