using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private float _currentForce;
    [SerializeField] private float _force = 200f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trampoline contact");
        Player _player = other.GetComponent<Player>();
        if (_player != null)
        {
            if (_player.Data.ID == "PSR")
                _currentForce = _force * 2.5f;
            else if (_player.Data.ID == "PPM")
                _currentForce = _force / 5;
            else
                _currentForce = _force / 2;

            _player.GetComponent<Rigidbody>().AddForce(transform.up * _currentForce * Time.deltaTime, ForceMode.Impulse);
        }
        else
        {
            _currentForce = _force;
            other.GetComponent<Rigidbody>().AddForce(transform.up * _currentForce * Time.deltaTime, ForceMode.Impulse);
        }

    }
}
