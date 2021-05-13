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
        //start playing sound
        hintSound.Play();
        //initialize animator
        _animator = GetComponent<Animator>();
        //start destriying coroutine 
        StartCoroutine(DestroyMyself());
    }

    private IEnumerator DestroyMyself()
    {
        //wait for life time
        yield return new WaitForSeconds(lifeTime);
        //start animation
        _animator.Play(animation);
        yield return new WaitForSeconds(1);
        //switch off the game object
        gameObject.SetActive(false);
    }
}
