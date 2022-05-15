using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Entities/Stats", order = 0)]
public class StatsSO : ScriptableObject
{
    public string ID => _id;
    [SerializeField] private string _id;
    public float Speed => _speed;
    [SerializeField] private float _speed;

    public float JumpSpeed => _jumpSpeed;
    [SerializeField] private float _jumpSpeed;

    public float MovementForce => _movementForce;
    [SerializeField] private float _movementForce;
    public float JumpForce => _jumpForce;
    [SerializeField] private float _jumpForce;
    public float MaxSpeed => _maxSpeed;
    [SerializeField] private float _maxSpeed;


    public float Mass => _mass;
    [SerializeField] private float _mass;
    public float Drag => _drag;
    [SerializeField] private float _drag;
    public float LinearDrag => _linearDrag;
    [SerializeField] private float _linearDrag;
}
