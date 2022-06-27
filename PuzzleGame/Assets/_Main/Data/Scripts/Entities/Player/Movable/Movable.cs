using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movable : MonoBehaviour, IMovable
{
    private Rigidbody _rigidbody;

    private Player _player;

    private Vector3 _forceDirection = Vector3.zero;


    [SerializeField] private Transform _camera;

    
    private void Awake()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
        if (Camera.main != null) _camera = Camera.main.transform;
    }

    public void Move(Vector3 direction)
    {
    Vector3 _rayCastOrigin = transform.position;
    Vector3 targetPosition;
    RaycastHit hit;
    targetPosition = transform.position;


        float currentForce;
        if (!_player.IsGrounded)
            currentForce = _player.GetStats.MovementForce / 3;
        else
            currentForce = _player.GetStats.MovementForce;
        
        
        _forceDirection = _camera.forward * direction.y;
        _forceDirection += _camera.right * direction.x;
        _forceDirection.Normalize();
        _forceDirection.y = 0;
        _forceDirection *= currentForce;

        //Por que?
        //forceDirection.y += -10;
        _rigidbody.AddForce(_forceDirection);

        _forceDirection = Vector3.zero;
        //Creo que esto deveria ir en otro script
        if (_rigidbody.velocity.y < 0f && !_player.IsInteracting)
            _rigidbody.velocity -= Vector3.down * (Physics.gravity.y * Time.fixedDeltaTime);

        //Encontre el problema de planear... era que estaba siendo multiplicado por Time.deltatime, igual la comento porque en jumpable hace lo mismo
        // Vector3 horizontalVelocity = _rigidbody.velocity;
        // horizontalVelocity.y = 0;
        // if (horizontalVelocity.sqrMagnitude > _player.GetStats.MaxSpeed * _player.GetStats.MaxSpeed)
        //     _rigidbody.velocity = horizontalVelocity.normalized * _player.GetStats.MaxSpeed + Vector3.up * _rigidbody.velocity.y;

        HandleRotation(direction);

        if (Physics.SphereCast(_rayCastOrigin, 0.2f, -Vector3.up, out hit ))
        {
            if (_player.IsGrounded)
            {
                Vector3 rayCastHitPoint = hit.point;
                targetPosition.y = rayCastHitPoint.y;
            }
        }

        if (_player.IsGrounded)
        {
           if( _player.IsInteracting )
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / 0.1f);
            }else
            {
                transform.position = targetPosition;
            }
        }
    }

    private void HandleRotation (Vector3 direction)
    {
        Vector3 targetDirection;

        targetDirection = _camera.forward * direction.y;
        targetDirection += _camera.right * direction.x;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, _player.GetStats.RotationSpeed);

        transform.rotation = playerRotation;

    }
}
