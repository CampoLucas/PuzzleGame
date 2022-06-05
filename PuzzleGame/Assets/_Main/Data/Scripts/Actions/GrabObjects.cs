using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    private GameObject _grabbedObject;

    [SerializeField] private Transform _rayPoint;
    [SerializeField] private Transform _hand;
    [SerializeField] private float _rayDistance;

    [SerializeField] private LayerMask _layerIndex;

    // Update is called once per frame
    private void Update()
    {
        
        Debug.DrawRay(_rayPoint.position, transform.forward * _rayDistance, Color.red);
    }

    public void GrabObject()
    {
        if (Physics.Raycast(_rayPoint.position, transform.forward, out RaycastHit hit, _rayDistance, _layerIndex))
        {
            if (_grabbedObject == null)
            {
                _grabbedObject = hit.collider.gameObject;
                _grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                //_grabbedObject.GetComponent<Rigidbody>().useGravity = false;
                _grabbedObject.transform.position = _hand.position;
                _grabbedObject.transform.SetParent(transform);
            }
            else if (_grabbedObject != null)
            {
                _grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                //_grabbedObject.GetComponent<Rigidbody>().useGravity = true;
                _grabbedObject.transform.SetParent(null);
                _grabbedObject = null;
            }

            Debug.Log("Hit");

        }

    }

    public void UpdateBoxPos()
    {
        if (_grabbedObject != null)
            _grabbedObject.transform.position = _hand.transform.position;
    }

}
