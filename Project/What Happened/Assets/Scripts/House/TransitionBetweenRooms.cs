using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBetweenRooms : MonoBehaviour
{
    private Animator animator;

    private void Start() 
    {
        // initialize components
        animator = GetComponent<Animator>(); 
    }
    private void OnEnable() 
    {
        // subscribe on events
        CorridorMiniGame._changeStateOfMiniGame += Animation;
        RoomsData.changeStateOfMiniGame += Animation;
        WalllsControll._transition += Animation;
        RoomsData._transition += Animation;
    }

    private void OnDisable()
    {
        //unsubscribe on events
        CorridorMiniGame._changeStateOfMiniGame -= Animation;
        RoomsData.changeStateOfMiniGame -= Animation;
        WalllsControll._transition -= Animation;
        RoomsData._transition -= Animation;
    }

    private void Animation()
    {
        // set animation trigger
        animator.SetTrigger("Transition");  
    }
}
