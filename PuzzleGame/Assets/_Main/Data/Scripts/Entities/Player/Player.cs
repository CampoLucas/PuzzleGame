using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player : Entity
{
    private IMovable _movement;
    private IJumpable _jump;
    
    private PlayerState _status;
    private GrabObjects _grabObjects;

    private DestroyObjects _destroyObjects;
    
    private Swap _swap;

    private ParticleTransition _particle;
    
    public bool IsGrounded => _status.IsGrounded;
    public bool IsInteracting => _status.IsInteracting;

    

    protected override void Awake()
    {
        base.Awake();
        _movement = GetComponent<IMovable>();
        _jump = GetComponent<IJumpable>();
        _status = GetComponent<PlayerState>();
        _grabObjects = GetComponentInChildren<GrabObjects>();
        _destroyObjects = GetComponent<DestroyObjects>();
        _particle = GetComponent<ParticleTransition>();
        
        
        _swap = GetComponent<Swap>();

    }

    protected override void Start()
    {
        base.Start();
        
        _swap.OnAfterChangeForm.AddListener(UpdateStats);
        if (_particle)
        {
            _swap.OnBeforeChangeForm.AddListener(_particle.PlayEffect);
            _particle.StopEffect();
        }

        //UpdateStats();
    }

    public void Move(Vector3 direction)
    {
        if(_movement != null)
            _movement.Move(direction);
    }

    public void Jump()
    {
        if(_jump != null)
            _jump.Jump();
    }

    public void GrabObject()
    {
        if (_grabObjects)
            _grabObjects.GrabObject();
    }


    public void SwapNext()
    {
        if(_swap)
            _swap.ChangeForm(true);
    }

    public void SwapPrevius()
    {
        if(_swap)
            _swap.ChangeForm(false);
    }
    public void SetIsInteracting(bool isInteracting)
    {
        if(_status != null)
            _status.SetIsInteracting(isInteracting);
    }

    public StatsSO GetStats => _swap.GetCurrentStats;
    private void UpdateStats()
    {
        _stats = GetStats;
        if (_grabObjects)
            _grabObjects.UpdateBoxPos();
    }

    public void Action()
    {
        if (Data.ID == "Player_Pyramid")
            _destroyObjects.Action();

    }


}
