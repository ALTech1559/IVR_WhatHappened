using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private int lifeTime;
    [SerializeField] private string animation = "HintDestroy";
    [SerializeField] private AudioSource hintSound;
    internal void PlayHint()
    {
        hintSound.Play();
        _animator = GetComponent<Animator>();
        StartCoroutine(DestroyMyself());
    }

    private IEnumerator DestroyMyself()
    {
        yield return new WaitForSeconds(lifeTime);
        _animator.Play(animation);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
