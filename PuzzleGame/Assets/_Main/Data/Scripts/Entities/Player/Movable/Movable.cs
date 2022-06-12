using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour, IMovable
{
    private Rigidbody _rigidbody;

    private Player _player;

    private Vector3 forceDirection = Vector3.zero;

    [SerializeField] Transform cameraObject;

    public float rotationSpeed = 25;

    
    private void Awake()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    public void Move(Vector3 direction)
    {


        if (_player.IsGrounded)
        {
            //forceDirection.x += direction.x * _player.Data.MovementForce * Time.deltaTime;
            //forceDirection.z += direction.y * _player.Data.MovementForce * Time.deltaTime;
            forceDirection = cameraObject.forward * direction.y;
            forceDirection = forceDirection + cameraObject.right * direction.x;
            forceDirection.Normalize();
            forceDirection.y = 0;
            forceDirection = forceDirection * _player.Data.MovementForce;




        }
        else
        {

            forceDirection = cameraObject.forward * direction.y;
            forceDirection = forceDirection + cameraObject.right * direction.x;
            forceDirection.Normalize();
            forceDirection.y = 0;
            forceDirection = forceDirection * _player.Data.MovementForce / 5;

        }

        //if (_rigidbody.velocity.y < 0)
        //{
        //    
        //}

        forceDirection.y += -10;
        _rigidbody.AddForce(forceDirection);

        forceDirection = Vector3.zero;
        //Creo que esto deveria ir en otro script
        if (_rigidbody.velocity.y < 0f && !_player.IsInteracting)
            _rigidbody.velocity -= Vector3.down * (Physics.gravity.y * Time.deltaTime);

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > _player.Data.MaxSpeed * _player.Data.MaxSpeed)
            _rigidbody.velocity = horizontalVelocity.normalized * _player.Data.MaxSpeed + Vector3.up * (_rigidbody.velocity.y * Time.deltaTime);

        HandleRotation(direction);
    }

    private void HandleRotation (Vector3 direction)
    {
        Vector3 targetDirection = Vector3.zero;

        targetDirection = cameraObject.forward * direction.y;
        targetDirection = targetDirection + cameraObject.right * direction.x;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;

    }
}
