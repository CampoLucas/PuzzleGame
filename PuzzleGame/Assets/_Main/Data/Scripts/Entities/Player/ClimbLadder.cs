using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    private Player _player;
    private Rigidbody _rigidbody;
    
    private Vector3 _forceDirection = Vector3.zero;
    
    private void Awake()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        _rigidbody.AddForce(_forceDirection, ForceMode.Force);
        _forceDirection = Vector3.zero;  
    }
    
    public void Climb()
    {
        _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
        _forceDirection += Vector3.up * (_player.GetStats.JumpForce * 3);

    }
}
