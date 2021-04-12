using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammerSpeechController : MonoBehaviour, ControllerInterface
{
    private GameObject Speech;

    public bool statement { get; set ; }

    private void OnEnable()
    {
        Speech = transform.GetChild(0).gameObject;
        PhoneControll._programmerSpeechAwake += ChangeStatement;
        ButtonsHolder.programmerSpeechDisable += ChangeStatement;
    }

    private void OnDisable()
    {
        PhoneControll._programmerSpeechAwake -= ChangeStatement;
        ButtonsHolder.programmerSpeechDisable -= ChangeStatement;
    }

    public void ChangeStatement()
    {
        statement = !statement;
        Speech.SetActive(statement);
    }
}
