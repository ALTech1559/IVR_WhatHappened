using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PasswordNoteController : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5;
    private GameObject Note;
    private Animator _animator;

    private void OnEnable()
    {
        //initialize components
        Note = transform.GetChild(0).gameObject;
        _animator = GetComponent<Animator>();
        //subscribe on events
        PhonePasswordNote._note_change_activity += SetActivity;
    }

    private void OnDisable()
    {
        //unsubscribe on events
        PhonePasswordNote._note_change_activity -= SetActivity;
    }

    private void SetActivity()
    {
        StartCoroutine(ShowNote());
    }

    private IEnumerator ShowNote()
    {
        //play activation and disable animation
        yield return new WaitForSeconds(1);
        Note.SetActive(true);
        _animator.Play("PhonePasswordAwake");
        yield return new WaitForSeconds(_lifeTime);
        _animator.Play("PhonePasswordDestroy");
        yield return new WaitForSeconds(1);
        Note.SetActive(false);
    }
}
