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
        // change the statement of sound
        isPlaying = !isPlaying; 
        // start playing music if it has not been played yet
        if (isPlaying) 
        {
            sound.Play();
        }
        else
        {
            //stop playing sound
            sound.Stop();
        }
    }
}
