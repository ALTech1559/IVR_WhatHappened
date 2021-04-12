using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] private float speed;
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -18)
        {
            Destroy(this.gameObject);
        }
    }
}
