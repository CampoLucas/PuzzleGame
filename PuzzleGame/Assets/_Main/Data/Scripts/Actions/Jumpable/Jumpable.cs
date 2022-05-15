using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpable : MonoBehaviour, IJumpable
{
    private Player _player;
    private Rigidbody _rigidbody;

    public float JumpForce => _jumpForce;
    [SerializeField] private float _jumpForce;
    public float MaxSpeed => _maxSpeed;
    [SerializeField] private float _maxSpeed;

    [SerializeField] private bool _useGravity = true;

    private Vector3 _forceDirection = Vector3.zero;


    public StatsSO Data => _stats;
    private StatsSO _stats;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
        _stats = _player.Data;
        InitStats();
    }

    private void InitStats()
    {
        _jumpForce = _stats.JumpForce;
        _maxSpeed = _stats.MaxSpeed;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(_forceDirection, ForceMode.Impulse);
        _forceDirection = Vector3.zero;

        if (_rigidbody.velocity.y < 0f && _useGravity)
            _rigidbody.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;
        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > _maxSpeed * _maxSpeed)
            _rigidbody.velocity = horizontalVelocity.normalized * _maxSpeed + Vector3.up * _rigidbody.velocity.y;
    }
    public void Jump()
    {
        if (_player.isGrounded())
            _forceDirection += Vector3.up * _jumpForce;
    }

    public void DisableGravity(bool isGravity) => _useGravity = isGravity;
}
