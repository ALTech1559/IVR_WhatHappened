using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammerSpeechController : MonoBehaviour, ControllerInterface
{
    private GameObject Speech;

    public bool statement { get; set ; }

    private void OnEnable()
    {
        //initialize components
        Speech = transform.GetChild(0).gameObject;
        //subscribe on events
        PhoneControll._programmerSpeechAwake += ChangeStatement;
        ButtonsHolder.programmerSpeechDisable += ChangeStatement;
    }

    private void OnDisable()
    {
        //unsubscribe on events
        PhoneControll._programmerSpeechAwake -= ChangeStatement;
        ButtonsHolder.programmerSpeechDisable -= ChangeStatement;
    }

    public void ChangeStatement()
    {
        //change flag
        statement = !statement;
        //change game object statement on the scene
        Speech.SetActive(statement);
    }
}
