using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WalllsControll : MonoBehaviour
{
    internal enum Name
    {
        stair1,
        corridor,
        cafe,
        kitchen,
        bedroom,
        bathroom,
        pantry,
        wordrop,
        stair2,
        balcony
    }

    [Header("Room name")]
    [SerializeField] private Name _room_name;

    [Header("Copmponents")]
    [SerializeField] private GameObject data;

    internal static bool isGoingOnTheNextFloor = false;
    internal static event UnityAction _change_room;
    internal static event UnityAction _transition;

    internal RoomsData RoomsData
    {
        get => default;
        set
        {
        }
    }

    private void OnEnable()
    {
        //subscribe on events
        ButtonsHolder.goOnTheSecondFloor += Event;
        ButtonsHolder.goOnTheFirstFloor += Event;
    }

    private void OnDisable()
    {
        ButtonsHolder.goOnTheSecondFloor -= Event;
        ButtonsHolder.goOnTheFirstFloor -= Event;
    }
    private void Event()
    {
        //start the event
        _transition?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //invoke function of changing the room
            data.GetComponent<RoomsData>().Movement(_room_name.ToString(), isGoingOnTheNextFloor);
            //set the event
            _change_room?.Invoke();
            isGoingOnTheNextFloor = false;
        }
    }
}
