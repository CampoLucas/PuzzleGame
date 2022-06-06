using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (!spawnPos)
        {
            spawnPos = new GameObject().transform;
            spawnPos.position = transform.position;
        }
    }

    private void Start()
    {
    }

    public void EntityRespawn()
    {
        transform.position = spawnPos.transform.position;
        _rigidbody.velocity = Vector3.zero;
    }
}
