using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRange : MonoBehaviour
{
    protected Player _player;
    
    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _offsetY = .7f;

    [SerializeField] private LayerMask _layerIndex;

    [SerializeField] protected Collider[] _hitColliders;
    
    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        _hitColliders =
            Physics.OverlapSphere(
                new Vector3(transform.position.x, transform.position.y + _offsetY, transform.position.z), _radius, _layerIndex);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y + _offsetY, transform.position.z), _radius);
    }
}
