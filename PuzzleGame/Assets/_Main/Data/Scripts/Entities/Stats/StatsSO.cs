using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Entities/Stats", order = 0)]
public class StatsSO : ScriptableObject
{
    public string ID => _id;
    [SerializeField] private string _id;
    
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


    public Vector3 HandPosition => _handPosition;
    [SerializeField] private Vector3 _handPosition;
    

    public Vector3 BodyCenter => _bodyCenter;
    [SerializeField] private Vector3 _bodyCenter;

    public float BodyRadius => _bodyRadius;
    [SerializeField] private float _bodyRadius;
    
    public float bodyHeight => _bodyHeight;
    [SerializeField] private float _bodyHeight;
}
