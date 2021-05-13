using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionScript : MonoBehaviour
{
    [Range(0, 3)]
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        LastMiniGameController.setOffScene += DestroyScene;
    }

    private void OnDisable()
    {
        LastMiniGameController.setOffScene -= DestroyScene;
    }

    private void AwakeScene()
    {
        animator.SetTrigger("SceneAwake");
    }

    private void DestroyScene()
    {
        animator.SetTrigger("SceneDestroy");
    }
}
