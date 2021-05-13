using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuController : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        // move person
        transform.Translate(Vector3.right * speed);
    }
}
