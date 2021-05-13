using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHolder : MonoBehaviour
{
    [Header("Lists")]
    [SerializeField] private List<GameObject> _bolts = new List<GameObject>();
    private bool _isLocked = true;

    public LightSwitch LightSwitch
    {
        get => default;
        set
        {
        }
    }

    public void Check()
    {
        //check bolts
        for(int i = 0; i < _bolts.Count; i++)
        {
            _isLocked = _bolts[i].activeInHierarchy;
        }

        if (_isLocked == false)
        {
            //play animation
            GetComponent<Animator>().Play("Falling");
        }
    }

}
