using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PhonePasswordNote : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] internal GameObject Note;
    public static event UnityAction _note_change_activity;

    private void Start()
    {
        //disactivate if key is not 1
        if (PlayerPrefs.GetInt("Phone") != 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //play animation
        GetComponent<Animator>().Play("NoteAwake");
        //invoke event
        _note_change_activity?.Invoke();
    }


}
