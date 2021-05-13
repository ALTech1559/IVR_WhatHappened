using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TakerSoundScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioSource takerSound;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!takerSound.isPlaying)
        {
            takerSound.Play();
        }
    }
}
