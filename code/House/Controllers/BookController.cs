using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour, ControllerInterface
{
    private GameObject Panel;
    private Animator _animator;
    public bool statement { get ; set ; }

    private void OnEnable()
    {
        Panel = transform.GetChild(0).gameObject;
        _animator = Panel.GetComponent<Animator>();
        ButtonsHolder.changeBookStatement += ChangeStatement;
    }

    private void OnDisable()
    {
        ButtonsHolder.changeBookStatement -= ChangeStatement;
    }

    public void ChangeStatement()
    {
        statement = !statement;
        StartCoroutine(SwitchOffPhone());
    }

    private IEnumerator SwitchOffPhone()
    {
        if(!statement)
        {
            _animator.Play("Sleep");
            yield return new WaitForSeconds(1f);
        }
        Panel.SetActive(statement);
    }

}
