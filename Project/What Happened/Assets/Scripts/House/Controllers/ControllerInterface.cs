using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ControllerInterface
{
    //statement flag
    bool statement { get; set; }
    //function if flag is changed
    void ChangeStatement();
}
