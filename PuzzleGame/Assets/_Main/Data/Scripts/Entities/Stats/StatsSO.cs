using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Entities/Stats", order = 0)]
public class StatsSO : ScriptableObject
{
    public string ID => _id;
    [SerializeField] private string _id;
    
    public Vector3 HandPosition => _handPosition;
    [SerializeField]private Vector3 _handPosition;
    
    public Vector3 RayPosition => _rayPosition;
    [SerializeField]private Vector3 _rayPosition;
    
    public float MovementForce => _stats.movementForce; 
    public float JumpForce => _stats.jumpForce;
    public float MaxSpeed => _stats.maxSpeed;


    public float Mass => _rigidbody.mass;
    public float Drag => _rigidbody.drag;
    

    [SerializeField] private StatValues _stats;
    [SerializeField] private RigidBodyValues _rigidbody;

}

[System.Serializable]
public struct StatValues
{
    public float movementForce;
    public float jumpForce;
    public float maxSpeed;
}
[System.Serializable]
public struct RigidBodyValues
{
    public float mass;
    public float drag;
}
