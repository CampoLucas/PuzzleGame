using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    private GameObject _grabbedObject;

    private Player _player;

    [SerializeField] private Transform _rayPoint;
    [SerializeField] private Transform _hand;
    [SerializeField] private float _rayDistance;
    
    [SerializeField] private float _radius = 1f;
    [SerializeField] private float _offsetY;

    [SerializeField] private LayerMask _layerIndex;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        _player.OnRespawn.AddListener(DropObj);
    }

    private void Update()
    {
        
        Debug.DrawRay(_rayPoint.position, transform.forward * _rayDistance, Color.red);
    }

    // public void GrabObject()
    // {
    //     if (Physics.Raycast(_rayPoint.position, transform.forward, out RaycastHit hit, _rayDistance, _layerIndex))
    //     {
    //         if (_grabbedObject == null)
    //         {
    //             _grabbedObject = hit.collider.gameObject.transform.parent.gameObject;
    //             GrabObj();
    //         }
    //         else if (_grabbedObject != null)
    //         {
    //             DropObj();
    //         }
    //
    //     }
    //
    // }
    
    public void GrabObject()
    {
        Collider[] hitColliders =
            Physics.OverlapSphere(
                new Vector3(transform.position.x, transform.position.y + _offsetY, transform.position.z), _radius, _layerIndex);
        
        foreach (var other in hitColliders)
        {
            Entity obj = other.GetComponent<Collider>().GetComponentInParent<Entity>();
            if (obj)
            {
                if (_grabbedObject == null)
                {
                    _grabbedObject = obj.gameObject;
                    GrabObj();
                }
                else if (_grabbedObject != null)
                {
                    DropObj();
                }
            }
        }
    
    }

    private void GrabObj()
    {
        _grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        //_grabbedObject.GetComponent<Rigidbody>().useGravity = false;
        _grabbedObject.transform.position = _hand.position;
        _grabbedObject.transform.SetParent(transform);
    }

    public void DropObj()
    {
        if (_grabbedObject)
        {
            _grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            //_grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            _grabbedObject.transform.SetParent(null);
            _grabbedObject = null;
            
        }
    }

    public void UpdateBoxPos()
    {
        if (_grabbedObject)
            _grabbedObject.transform.position = _hand.transform.position;
    }

}
