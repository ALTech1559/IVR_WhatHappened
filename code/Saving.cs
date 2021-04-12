using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal enum Current_scene
{
    house,
    street
}

public class Saving : MonoBehaviour
{
    [SerializeField] private Current_scene _current_scene;

    private void OnEnable()
    {
        WalllsControll._change_room += Save;
    }

    private void OnDisable()
    {
        WalllsControll._change_room -= Save;
    }

    private void Save()
    {
        Debug.Log("saved!");
    }
}
