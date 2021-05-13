using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TrapInBarn : MonoBehaviour, IPointerClickHandler
{
    [Header("GameObjects")]
    [SerializeField] private GameObject RopeTrap;
    [SerializeField] private GameObject _ask_to_hide;
    [SerializeField] private GameObject _final_speech;
    [SerializeField] private GameObject _player;
    [Header("Animator")]
    [SerializeField] private Animator _scene_transition;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PlayerPrefs.GetInt("Trap") == 1 && PlayerPrefs.GetInt("TrapSecond") == 1)
        {
            //change statement
            _ask_to_hide.SetActive(true);
            RopeTrap.SetActive(true);
            StartCoroutine(StartEvent());
        }
    }

    private IEnumerator StartEvent()
    {
        //wait for player
        yield return new WaitForSeconds(10);
        yield return new WaitUntil(() => Vector3.Distance(_player.transform.position, gameObject.transform.position) > 10);
        _final_speech.SetActive(true);
        yield return new WaitForSeconds(5);
        PlayerPrefs.SetInt("LastGame", 1);
        SceneLoading.ChangeScene("LastMiniGame");
    }
}

