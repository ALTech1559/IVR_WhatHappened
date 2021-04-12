﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LightControllerHolder : MonoBehaviour, IPointerClickHandler
{
    [Header("GameObjects")]
    [SerializeField] private GameObject FirstMiniGame;
    [SerializeField] private GameObject LightControllerUI;
    [SerializeField] private GameObject Joistic;
    [SerializeField] private GameObject Player;
    private Animator _animator;

    internal static event UnityAction _joystickChangeStatement;

    public void OnPointerClick(PointerEventData eventData)
    {
        _animator = LightControllerUI.GetComponent<Animator>();
        OpenPanel();
    }

    public void OpenPanel()
    {
        if (PlayerPrefs.GetString("LightController") != "open")
        {
            if (Player.transform.position.x < 67)
            {
                FirstMiniGame.SetActive(true);
            }
            _joystickChangeStatement?.Invoke();
        }
        else
        {
            Joistic.SetActive(false);
            FirstMiniGame.SetActive(false);
            LightControllerUI.SetActive(true);
        }

    }

    private void OnEnable()
    {
        ButtonsHolder.closeLightControllerPanel += ClosePanel;
    }

    private void OnDisable()
    {
        ButtonsHolder.closeLightControllerPanel -= ClosePanel;
    }

    private void ClosePanel()
    {
        Joistic.SetActive(true);
        StartCoroutine(CloseAnimation());
    }

    private IEnumerator CloseAnimation()
    {
        _animator.Play("Light Controller OnDisable");
        yield return new WaitForSeconds(1f);
        LightControllerUI.SetActive(false);
    }
}
