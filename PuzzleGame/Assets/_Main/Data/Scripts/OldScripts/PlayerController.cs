using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/*
public class PlayerController : MonoBehaviour
{
    //input fields
    private PlayerInput playerActionsAssets;
    private InputAction move;

    // jumpo force
    [SerializeField]
    private float jumpForce = 5f;

    //movement fields
    private Rigidbody rb;
    [SerializeField]
    private float movementForce = 1f;
    [SerializeField]
    private float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    public float distToGround = 1f;

    //layer floor
    [SerializeField]
    private LayerMask floorLayerMask;

    [SerializeField]
    private Camera playerCamera;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        playerActionsAssets = new PlayerInput();
    }

    private void OnEnable()
    {
        move = playerActionsAssets.Player.Move;
        playerActionsAssets.Player.Jump.started += DoJump;
        playerActionsAssets.Player.Enable();
    }

    private void OnDisable()
    {
        playerActionsAssets.Player.Jump.started -= DoJump;
        playerActionsAssets.Player.Disable();
    }

    private void FixedUpdate()
    {


        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraFoward(playerCamera) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

     }

    private Vector3 GetCameraFoward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCamera(Vector3 direction)
    {
        Vector3 forward = direction;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        Debug.Log("entroo JUMP");

       // if (IsGrounded())
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
*/