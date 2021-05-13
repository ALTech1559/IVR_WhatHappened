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
        //initialization of components
        Panel = transform.GetChild(0).gameObject;
        _animator = Panel.GetComponent<Animator>();
        //subscribe on events
        ButtonsHolder.changeBookStatement += ChangeStatement;
    }

    private void OnDisable()
    {
        ButtonsHolder.changeBookStatement -= ChangeStatement;
    }

    public void ChangeStatement()
    {
        //change statement
        statement = !statement;
        //start coroutine of animation
        StartCoroutine(SwitchOffPhone());
    }

    private IEnumerator SwitchOffPhone()
    {
        if(!statement)
        {
            //start animation
            _animator.Play("Sleep");
            //wait for time
            yield return new WaitForSeconds(1f);
        }
        //switch off the pone panel
        Panel.SetActive(statement);
    }
}
