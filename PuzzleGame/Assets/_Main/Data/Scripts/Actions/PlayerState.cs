using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    //layer floor
   // [SerializeField] private LayerMask floorLayerMask;

    //IS GROUND FUNCTION
    public bool IsGrounded()
    {
        if(Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 0.25f))
            return true;
        else
        {
            Debug.Log("no toca");
            return false;
        }
            
    }
}
