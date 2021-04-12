using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class VacumeMachine : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioSource sound;
    private bool isPlaying = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        isPlaying = !isPlaying;
        if (isPlaying)
        {
            sound.Play();
        }
        else
        {
            sound.Stop();
        }
    }

}
