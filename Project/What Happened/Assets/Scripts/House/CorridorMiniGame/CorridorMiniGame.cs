using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CorridorMiniGame : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject MiniGame;
    [SerializeField] private GameObject ButtonOnTheSecondFloor;
    [SerializeField] private CorridorKey Key;
    internal static event UnityAction _changeStateOfMiniGame;
    internal static event UnityAction _joystickChangeStatement;
    private BoxCollider _boxConllider;

    private void Start()
    {
        //initialize component
        _boxConllider = GetComponent<BoxCollider>();
        _boxConllider.enabled = false;
    }

    private void OnEnable()
    {
        //subscribe on events
        RoomsData.changeStateOfMiniGame += EventReaction;
    }

    private void OnDisable()
    {
        //unsubscribe on events
        RoomsData.changeStateOfMiniGame -= EventReaction;
    }

    private void EventReaction()
    {
        StartCoroutine(OnEnableMiniGame());
    }

    private IEnumerator OnEnableMiniGame()
    {
        _changeStateOfMiniGame?.Invoke();
        yield return new WaitForSeconds(0.55f);
        //change objects statement
        MiniGame.SetActive(true);
        ButtonOnTheSecondFloor.SetActive(false);
        _boxConllider.enabled = true;
    }

    private IEnumerator OnDisableMiniGame()
    {
        _changeStateOfMiniGame?.Invoke();
        yield return new WaitForSeconds(0.55f);
        //change key
        PlayerPrefs.SetInt("CorridorGame", 1);
        _joystickChangeStatement?.Invoke();
        //change objects statement
        ButtonOnTheSecondFloor.SetActive(true);
        MiniGame.SetActive(false);
        _boxConllider.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bool hit = Key.ShootRay();
        //if ray hitted the object
        if (hit)
        {
            StartCoroutine(OnDisableMiniGame());
        }
    }
}
