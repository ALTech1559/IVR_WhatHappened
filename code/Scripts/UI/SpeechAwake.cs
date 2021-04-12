﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeechAwake : MonoBehaviour
{
    public static event UnityAction switchOffLight;
    private Animator animator;
    [SerializeField] private bool isPoweringLight;
    [SerializeField] private bool allowToGoToStreet;
    [SerializeField] private int lifeTime;
    private string animationName = "SpeechDestroy";
    private void Start()
    {
        if (allowToGoToStreet)
        {
            PlayerPrefs.SetInt("AllowToStreet", 1);
        }
        if (isPoweringLight)
        {
            switchOffLight?.Invoke();
        }
        animator = GetComponent<Animator>();
        StartCoroutine(DestroyMyself());
    }

    private IEnumerator DestroyMyself()
    {
        yield return new WaitForSeconds(lifeTime);
        animator.Play("SpeechDestroy");
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
