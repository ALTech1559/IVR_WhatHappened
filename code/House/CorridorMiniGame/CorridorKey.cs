using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorKey : MonoBehaviour
{
    [SerializeField] private Transform RayPoint;
    internal bool ShootRay()
    {
        Ray ray = new Ray(RayPoint.position, Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<CapsuleCollider>() != null)
            {
                return true;
            }
        }
        return false;
    }
}
  