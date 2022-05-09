using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    private GameObject _grabbedObject;
    [SerializeField]private LayerMask _layerIndex;

    Collider other;

    // Update is called once per frame
    private void Update()
    {
        //GrabObject(false);
    }

    private void OnTriggerStay(Collider other)
    {
        this.other = other;
    }

    public void GrabObject(bool input)
    {
        if (((1 << other.gameObject.layer) & _layerIndex) != 0)
        {
            if (input && _grabbedObject == null)
            {
                _grabbedObject = other.gameObject;
                _grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                //_grabbedObject.GetComponent<Rigidbody>().useGravity = false;
                _grabbedObject.transform.position = transform.position;
                _grabbedObject.transform.SetParent(transform);
            }
            else if (input && _grabbedObject != null)
            {
                _grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                //_grabbedObject.GetComponent<Rigidbody>().useGravity = true;
                _grabbedObject.transform.SetParent(null);
                _grabbedObject = null;
            }

            Debug.Log("Hit");
        }
        
    }

}
