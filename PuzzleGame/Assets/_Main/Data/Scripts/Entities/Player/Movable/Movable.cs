using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour, IMovable
{
    private Rigidbody _rigidbody;

    private Player _player;
    
    private Vector3 forceDirection = Vector3.zero;

    
    private void Awake()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        if (_player.IsGrounded)
        {
            forceDirection.x += direction.x * _player.Data.MovementForce * Time.deltaTime;
            forceDirection.z += direction.y * _player.Data.MovementForce * Time.deltaTime;
            
        }
        else
        {
            forceDirection.x += direction.x * (_player.Data.MovementForce / 3) * Time.deltaTime;
            forceDirection.z += direction.y * (_player.Data.MovementForce / 3) * Time.deltaTime;
        }

        
        
        _rigidbody.AddForce(forceDirection);


        forceDirection = Vector3.zero;
        //Creo que esto deveria ir en otro script
        if (_rigidbody.velocity.y < 0f && !_player.IsInteracting)
            _rigidbody.velocity -= Vector3.down * (Physics.gravity.y * Time.deltaTime);

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > _player.Data.MaxSpeed * _player.Data.MaxSpeed)
            _rigidbody.velocity = horizontalVelocity.normalized * _player.Data.MaxSpeed + Vector3.up * (_rigidbody.velocity.y * Time.deltaTime);

    }
}
