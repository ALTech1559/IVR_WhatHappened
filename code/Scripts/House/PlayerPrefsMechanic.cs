using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsMechanic
{
    static public void ChangeValuse(string current_name, int new_value)
    {
        PlayerPrefs.SetInt(current_name, new_value);
    }

    static public int GetValue(string current_name)
    {
        return PlayerPrefs.GetInt(current_name);
    }

    static public bool HasKey(string current_name)
    {
        return PlayerPrefs.HasKey(current_name);
    }
}
