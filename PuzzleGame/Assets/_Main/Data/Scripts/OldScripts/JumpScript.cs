using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
public class JumpScript : MonoBehaviour
{
    private PlayerInput playerActionsAssets;

    [SerializeField]
    private float jumpForce = 5f;

    private Vector3 forceDirection = Vector3.zero;

    //layer floor
    [SerializeField]
    private LayerMask floorLayerMask;

    private void Awake()
    {
        playerActionsAssets = new PlayerInput();
    }

    private void OnEnable()
    {
        playerActionsAssets.Player.Jump.started += DoJump;
    }

    private void OnDisable()
    {
        playerActionsAssets.Player.Jump.started -= DoJump;
    }


    private void DoJump(InputAction.CallbackContext obj)
    {
        Debug.Log("entroo JUMP");

        if (IsGrounded())
        {

            forceDirection += Vector3.up * jumpForce;
        }

    }

    private bool IsGrounded()
    {


        //Ray ray = new Ray(this.transform.position, Vector3.down);

        // Debug.Log(ray);
        //Debug.Log(Physics.Raycast(ray, out hit, distToGround + 0.1f, floorLayerMask));
        // Debug.Log(this.transform.position + Vector3.up * 0.25f);
        // Debug.Log(Vector3.down);
        //Debug.Log(floorLayerMask);

        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);

        Debug.Log(Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f, floorLayerMask))
            return true;
        else
            Debug.Log("no toca");
        return false;

    }
}
*/