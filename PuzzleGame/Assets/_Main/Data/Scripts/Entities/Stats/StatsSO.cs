using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Entities/Stats", order = 0)]
public class StatsSO : ScriptableObject
{
    public string ID => _id;
    [SerializeField] private string _id;
    public GameObject ModelPrefab => _modelPrefab;
    [SerializeField] private GameObject _modelPrefab;
    public Vector3 HandPosition => _handPosition;
    [SerializeField]private Vector3 _handPosition;
    
    public float MovementForce => _stats.movementForce; 
    public float JumpForce => _stats.jumpForce;
    public float MaxSpeed => _stats.maxSpeed;


    public float Mass => _rigidbody.mass;
    public float Drag => _rigidbody.drag;
    public float LinearDrag => _rigidbody.linearDrag;
    

    [SerializeField] private StatValues _stats;
    [SerializeField] private RigidBodyValues _rigidbody;
    [SerializeField] private ColliderValues _head;
    [SerializeField] private ColliderValues _body;

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
    public float linearDrag;
}
[System.Serializable]
public struct ColliderValues
{
    public Vector3 bodyCenter;
    public float bodyRadius;
    public float bodyHeight;
}
