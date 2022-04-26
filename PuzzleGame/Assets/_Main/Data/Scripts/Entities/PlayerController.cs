using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //layer floor
    [SerializeField] private LayerMask floorLayerMask;

    //IS GROUND FUNCTION
    public bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.down * 0.25f, Vector3.down);
        Debug.Log(Vector3.down * 1);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.25f, floorLayerMask))
            return true;
        else
            Debug.Log("no toca");
        return false;
    }
}
