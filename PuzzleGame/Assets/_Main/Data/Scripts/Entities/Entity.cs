using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour
{
    private Respawn _respawn;
    public StatsSO Data => _stats;
    [SerializeField] protected StatsSO _stats;
    
    [Header("Events")] 
    public UnityEvent OnRespawn = new UnityEvent();

    protected virtual void Awake()
    {
        _respawn = GetComponent<Respawn>();
    }

    protected virtual void Start()
    {
        Respawn();
    }

    public void Respawn()
    {
        OnRespawn?.Invoke();
        if(_respawn)
            _respawn.EntityRespawn();
        
    }
}
