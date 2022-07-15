using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public bool IsGrounded => _isGrounded;
    [SerializeField] private bool _isGrounded;
    public bool IsInteracting => _isInteracting;
    [SerializeField] private bool _isInteracting;
    public bool IsClimbing => _isClimbing;
    [SerializeField]private bool _isClimbing;

    [SerializeField] private Transform _feet;
    [SerializeField] private LayerMask _player;
    

    private void Update()
    {
        var transform1 = transform;
        //_isGrounded = Physics.Raycast(transform1.position, -transform1.up, out RaycastHit hit, 0.25f);
        _isGrounded = Physics.CheckBox(_feet.transform.position, _feet.localScale, Quaternion.identity, _player);

    }

    public void SetIsInteracting(bool isInteracting) => _isInteracting = isInteracting;
    public void SetIsClimbing(bool isClimbing) => _isClimbing = isClimbing;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_feet.position, _feet.localScale);
    }
}
