using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpable : MonoBehaviour, IJumpable
{
    private Player _player;
    private Rigidbody _rigidbody;

    
    private Vector3 _forceDirection = Vector3.zero;


    public StatsSO Data => _stats;
    private StatsSO _stats;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
        _stats = _player.Data;
    }
    private void FixedUpdate()
    {
        _rigidbody.AddForce(_forceDirection, ForceMode.Impulse);
        _forceDirection = Vector3.zero;

        if (_rigidbody.velocity.y < 0f && !_player.IsInteracting)
            _rigidbody.velocity -= Vector3.down * (Physics.gravity.y * Time.fixedDeltaTime);
        var horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > _player.Data.MaxSpeed * _player.Data.MaxSpeed)
            _rigidbody.velocity = horizontalVelocity.normalized * _player.Data.MaxSpeed + Vector3.up * _rigidbody.velocity.y;
    }
    public void Jump()
    {
        if (_player.IsGrounded && !_player.IsInteracting)
            _forceDirection += Vector3.up * _player.Data.JumpForce;
    }

}
