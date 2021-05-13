using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LightControllerHolder : MonoBehaviour, IPointerClickHandler
{
    [Header("GameObjects")]
    [SerializeField] private GameObject FirstMiniGame;
    [SerializeField] private GameObject LightControllerUI;
    [SerializeField] private GameObject Joistic;
    [SerializeField] private GameObject Player;
    private Animator _animator;

    internal static event UnityAction _joystickChangeStatement;

    public BlockHolder BlockHolder
    {
        get => default;
        set
        {
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //initialize animator
        _animator = LightControllerUI.GetComponent<Animator>();
        OpenPanel();
    }

    public void OpenPanel()
    {
        if (PlayerPrefs.GetString("LightController") != "open")
        {
            if (Player.transform.position.x < 67)
            {
                FirstMiniGame.SetActive(true);
            }
            _joystickChangeStatement?.Invoke();
        }
        else
        {
            //change statement
            Joistic.SetActive(false);
            FirstMiniGame.SetActive(false);
            LightControllerUI.SetActive(true);
        }

    }

    private void OnEnable()
    {
        //subscribe on events
        ButtonsHolder.closeLightControllerPanel += ClosePanel;
    }

    private void OnDisable()
    {
        //unsubscribe on events
        ButtonsHolder.closeLightControllerPanel -= ClosePanel;
    }

    private void ClosePanel()
    {
        //activate objects
        Joistic.SetActive(true);
        StartCoroutine(CloseAnimation());
    }

    private IEnumerator CloseAnimation()
    {
        //play animation
        _animator.Play("Light Controller OnDisable");
        yield return new WaitForSeconds(1f);
        LightControllerUI.SetActive(false);
    }
}
