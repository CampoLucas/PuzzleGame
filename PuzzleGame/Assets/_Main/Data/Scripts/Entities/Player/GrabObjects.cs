using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : SphereRange
{
    private GameObject _grabbedObject;

    [SerializeField] private Transform _hand;
    private void Start()
    {
        _player.OnRespawn.AddListener(DropObj);
    }

    public void GrabObject()
    {
        foreach (var other in _hitColliders)
        {
            Entity obj = other.GetComponent<Collider>().GetComponentInParent<Entity>();
            if (obj)
            {
                if (!_grabbedObject)
                {
                    _grabbedObject = obj.gameObject;
                    GrabObj();
                }
                else if (_grabbedObject)
                {
                    DropObj();
                }
            }
        }
    
    }

    private void GrabObj()
    {
        if (!_grabbedObject) return;
        Destroy(_grabbedObject.GetComponent<Rigidbody>()); // .isKinematic = true;
        //_grabbedObject.GetComponent<Rigidbody>().useGravity = false;
        _grabbedObject.transform.position = _hand.position;
        _grabbedObject.transform.rotation = transform.rotation;
        _grabbedObject.transform.SetParent(transform);
    }

    public void DropObj()
    {
        if (_grabbedObject)
        {
            _grabbedObject.AddComponent<Rigidbody>(); 
            //_grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            _grabbedObject.transform.SetParent(null);
            _grabbedObject = null;
            
        }
    }

    public void UpdateBoxPos()
    {
        //_hand.transform.position = transform.position + _player.GetStats.HandPosition;
        if (_grabbedObject)
            _grabbedObject.transform.position = _hand.transform.position;
    }

}
