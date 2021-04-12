﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHolder : MonoBehaviour
{
    [Header("Lists")]
    [SerializeField] private List<GameObject> _bolts = new List<GameObject>();
    private bool _isLocked = true;
    public void Check()
    {
        for(int i = 0; i < _bolts.Count; i++)
        {
            _isLocked = _bolts[i].activeInHierarchy;
        }

        if (_isLocked == false)
        {
            GetComponent<Animator>().Play("Falling");
        }
    }

}
