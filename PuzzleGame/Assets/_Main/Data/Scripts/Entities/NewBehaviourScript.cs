using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    private float _currentForce;
    [SerializeField] private float force = 200f;
    [SerializeField] private LayerMask layerMask;
    
    [Header("collitionPos1")]
    [Header("Collition 1")]
    [SerializeField] private Transform _collition1;
    [SerializeField] private Color _color = Color.blue;

    [Header("Events")] 
    public UnityEvent OnCollition = new UnityEvent();

    private Collider[] _hitColliders;

    private void Start()
    {
        OnCollition.AddListener(TheCollition);
    }

    private void FixedUpdate()
    {
        MyCollisions();
    }

    private void MyCollisions()
    {
        _hitColliders = Physics.OverlapBox(_collition1.position, _collition1.localScale/2,
            Quaternion.identity, layerMask);
        int i = 0;
        if (_hitColliders != null && i < _hitColliders.Length)
        {
            OnCollition?.Invoke();
            i++;
        }
    }

    private void TheCollition()
    {
        foreach (Collider collition in _hitColliders)
        {
            Player player = collition.GetComponent<Player>();

            if (player)
            {
                if (player.Data.ID == "PSR")
                    _currentForce = force * 2.5f;
                else if (player.Data.ID == "PPM")
                    _currentForce = force / 15;
                else
                    _currentForce = force / 2;
            }
            else
            {
                _currentForce = force;
            }
                
            collition.GetComponent<Rigidbody>().AddForce(transform.up * _currentForce * Time.deltaTime, ForceMode.Impulse);
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireCube(_collition1.position, _collition1.localScale);
    }
}
