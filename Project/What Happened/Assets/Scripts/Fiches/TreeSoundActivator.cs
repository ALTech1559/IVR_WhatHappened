using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TreeSoundActivator : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioSource leavesTree;

    public void OnPointerClick(PointerEventData eventData) 
    {
        //start playing sound if it has not been played yet
        if (leavesTree.isPlaying == false) 
        {
            leavesTree.Play();
        }
    }
}
