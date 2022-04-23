using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody _rigidbody;
    private Vector3 forceDirection = Vector3.zero;

    [Header("Stats")]//Despues van a ir en su script de stats
    [SerializeField] private float jumpForce = 5f;
    
    public void Do()
    {
        if (IsGrounded())
            forceDirection += Vector3.up * jumpForce;
    }

    private bool IsGrounded()
    {

        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);

        Debug.Log(Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f, 1 >> 6))
            return true;
        else
            Debug.Log("no toca");
        return false;

    }
}
