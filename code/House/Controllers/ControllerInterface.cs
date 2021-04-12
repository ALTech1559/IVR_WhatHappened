using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ControllerInterface
{
    bool statement { get; set; }

    void ChangeStatement();
}
