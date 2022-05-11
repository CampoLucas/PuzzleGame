using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private PlayerControls playerActionsAssets;
    private InputAction move;

    [SerializeField] private float movementForce = 2000f;

    //[SerializeField] private float movementForce = 1f;
    [SerializeField] private float maxSpeed = 5f;

    private Vector3 forceDirection = Vector3.zero;

    private void Awake()
    {
        playerActionsAssets = new PlayerControls();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    { 
        move = playerActionsAssets.PlayerMovements.Movement;
    }

    public void Move(float horizontal, float vertical)
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * maxSpeed * -horizontal);
        //transform.Translate(Vector3.right * Time.deltaTime * maxSpeed * vertical);

        forceDirection.x += horizontal  * movementForce * Time.deltaTime;
        forceDirection.z += vertical * movementForce * Time.deltaTime;
        Debug.DrawRay(transform.position, transform.forward);

        _rigidbody.AddForce(forceDirection);


        forceDirection = Vector3.zero;

        if (_rigidbody.velocity.y < 0f)
            _rigidbody.velocity -= Vector3.down * Physics.gravity.y * Time.deltaTime;

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            _rigidbody.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * _rigidbody.velocity.y;
    }

    private Vector3 GetCamera(Vector3 direction)
    {
        Vector3 forward = direction;
        forward.y = 0;
        return forward.normalized;
    }

}
