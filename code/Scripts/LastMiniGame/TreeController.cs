using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    [Range(1,100)]
    [SerializeField] private float _speed;
    private void Update()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        if (transform.position.x < -18)
        {
            Destroy(this.gameObject);
        }
    }
}
