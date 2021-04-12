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
        if (PlayerPrefs.GetInt("Phone") != 1)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<Animator>().Play("NoteAwake");
        _note_change_activity?.Invoke();
    }


}
