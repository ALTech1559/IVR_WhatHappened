using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorKey : MonoBehaviour
{
    [SerializeField] private Transform RayPoint;
    internal bool ShootRay()
    {
        //create ray
        Ray ray = new Ray(RayPoint.position, Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //if ray hit in object with component CapsuleCollider
            if (hit.transform.gameObject.GetComponent<CapsuleCollider>() != null)
            {
                return true;
            }
        }
        return false;
    }
}
  