using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour, IMovable
{
    private Rigidbody _rigidbody;

    public float MovementForce => _movementForce;
    [SerializeField] private float _movementForce;

    public float MaxSpeed => _maxSpeed;
    [SerializeField] private float _maxSpeed;

    private Vector3 forceDirection = Vector3.zero;

    public StatsSO Data => _stats;
    private StatsSO _stats;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _stats = GetComponent<Player>().Data;
        InitStats();
    }

    private void InitStats()
    {
        _movementForce = _stats.MovementForce;
        _maxSpeed = _stats.MaxSpeed;
    }

    public void Move(Vector3 direction)
    {
        forceDirection.x += direction.x * _movementForce * Time.deltaTime;
        forceDirection.z += direction.y * _movementForce * Time.deltaTime;
        Debug.DrawRay(transform.position, transform.forward);

        _rigidbody.AddForce(forceDirection);


        forceDirection = Vector3.zero;
        //Creo que esto deveria ir en otro script
        if (_rigidbody.velocity.y < 0f)
            _rigidbody.velocity -= Vector3.down * Physics.gravity.y * Time.deltaTime;

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > _maxSpeed * _maxSpeed)
            _rigidbody.velocity = horizontalVelocity.normalized * _maxSpeed + Vector3.up * _rigidbody.velocity.y * Time.deltaTime;
    }
}
