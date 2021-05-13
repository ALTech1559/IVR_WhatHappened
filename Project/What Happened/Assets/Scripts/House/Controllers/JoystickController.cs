using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour, ControllerInterface
{
    private GameObject Joystick;

    [HideInInspector] public bool statement { get ; set; }

    private void OnEnable()
    {
        //initialize joystick game object
        Joystick = transform.GetChild(0).gameObject;
        //subscribe on events
        LightControllerHolder._joystickChangeStatement += ChangeStatement;
        CorridorMiniGame._joystickChangeStatement += ChangeStatement;
        ButtonsHolder.joystickChangeStatement += ChangeStatement;
        RoomsData.joystickStatement += ChangeStatement;
    }

    private void OnDisable()
    {
        //unsubscribe on events
        LightControllerHolder._joystickChangeStatement -= ChangeStatement;
        CorridorMiniGame._joystickChangeStatement -= ChangeStatement;
        ButtonsHolder.joystickChangeStatement -= ChangeStatement;
        RoomsData.joystickStatement -= ChangeStatement;
    }

    public void ChangeStatement()
    {
        //change statement
        Joystick.SetActive(statement);
        statement = !statement;
    }
}
