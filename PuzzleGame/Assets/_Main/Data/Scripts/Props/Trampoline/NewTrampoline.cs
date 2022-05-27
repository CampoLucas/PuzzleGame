using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTrampoline : MonoBehaviour
{
    private ITriggerable _triggerable;
    
    private float _currentForce;
    [SerializeField] private float force = 200f;
    

    private void Awake()
    {
        _triggerable = GetComponent<ITriggerable>();
    }

    private void Start()
    {
        _triggerable?.OnCollition.AddListener(Bounce);
    }

    private void Bounce()
    {
        foreach (Collider collition in _triggerable.HitColliders)
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
}
