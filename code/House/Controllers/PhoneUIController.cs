using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneUIController : MonoBehaviour, ControllerInterface
{
    private GameObject _panel;
    private Animator _animator;
    public bool statement { get ; set ; }

    private void OnEnable()
    {
        _panel = transform.GetChild(0).gameObject;
        _animator = _panel.GetComponent<Animator>();
        ButtonsHolder.changePhoneStatement += ChangeStatement;
    }

    private void OnDisable()
    {
        ButtonsHolder.changePhoneStatement -= ChangeStatement;
    }

    public void ChangeStatement()
    {
        statement = !statement;
        StartCoroutine(SwitchOffPhone());
    }

    private IEnumerator SwitchOffPhone()
    {
        if (statement)
        {
            _animator.Play("PhoneAwake2");
        }
        else
        {
            _animator.Play("DestroyPhone");
            yield return new WaitForSeconds(1f);
        }
        _panel.SetActive(statement);
    }

}
