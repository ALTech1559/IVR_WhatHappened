using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrickTap : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _speech;

    private void Start()
    {
        if (PlayerPrefs.HasKey("TrapSecond") == true)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerPrefs.SetInt("TrapSecond", 1);
        _speech.SetActive(true);
        Destroy(this.gameObject);
    }
}
