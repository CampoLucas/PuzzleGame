using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;

    private GameObject grabbedGameObject;
    [SerializeField]private LayerMask layerIndex;

    RaycastHit hitInfo;

    // Update is called once per frame
    private void Update()
    {
        //if(Physics.Raycast(rayPoint.position, transform.forward, out RaycastHit hit))
        //{
        //    if(hit.collider != null && hit.collider.gameObject.layer == layerIndex)
        //        Debug.Log("hit");
        //}

        //if (Physics.Raycast(rayPoint.position, transform.forward, out RaycastHit hit, rayDistance))
        //{
        //    Debug.Log("hit");
        //}

        //if (Physics.Raycast(rayPoint.position, transform.forward, out RaycastHit hit))
        //{
        //    Debug.Log("hit");
        //}

        //RaycastHit hit;
        //Physics.Raycast(rayPoint.position, transform.forward, out hit, rayDistance);
        //if(hit.collider != null)
        //{
        //    Debug.Log("hit");
        //}

        Debug.DrawRay(rayPoint.position, transform.forward * rayDistance, Color.red);
    }

    private bool IsNearObject()
    {
        if (Physics.Raycast(rayPoint.position, transform.forward))
        {
            return true;
        }

        return false;
    }

}
