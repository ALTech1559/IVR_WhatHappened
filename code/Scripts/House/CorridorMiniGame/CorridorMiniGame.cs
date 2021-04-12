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
        _boxConllider = GetComponent<BoxCollider>();
        _boxConllider.enabled = false;
    }

    private void OnEnable()
    {
        RoomsData.changeStateOfMiniGame += EventReaction;
    }

    private void OnDisable()
    {
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
        MiniGame.SetActive(true);
        ButtonOnTheSecondFloor.SetActive(false);
        _boxConllider.enabled = true;
    }

    private IEnumerator OnDisableMiniGame()
    {
        _changeStateOfMiniGame?.Invoke();
        yield return new WaitForSeconds(0.55f);
        PlayerPrefs.SetInt("CorridorGame", 1);
        _joystickChangeStatement?.Invoke();
        ButtonOnTheSecondFloor.SetActive(true);
        MiniGame.SetActive(false);
        _boxConllider.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bool hit = Key.ShootRay();
        if (hit)
        {
            StartCoroutine(OnDisableMiniGame());
        }
    }
}
