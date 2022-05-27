using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bounce : MonoBehaviour, ITriggerable
{
    public Collider[] HitColliders => _hitColliders;
    private Collider[] _hitColliders;
    
    public UnityEvent OnCollition => _onCollition;
    private UnityEvent _onCollition = new UnityEvent();
    
    [Header("Collider components")]
    [SerializeField] private Transform _collition;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Color _color = Color.white;
    
    private void FixedUpdate()
    {
        MyCollisions();
    }
    
    private void MyCollisions()
    {
        _hitColliders = Physics.OverlapBox(_collition.position, _collition.localScale/2,
            Quaternion.identity, layerMask);
        int i = 0;
        if (_hitColliders != null && i < _hitColliders.Length)
        {
            OnCollition?.Invoke();
            i++;
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawWireCube(_collition.position, _collition.localScale);
    }
}
