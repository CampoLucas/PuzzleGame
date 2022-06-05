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
    
    private Swap _swap;
    
    public bool IsGrounded => _status.IsGrounded;
    public bool IsInteracting => _status.IsInteracting;

    

    protected override void Awake()
    {
        base.Awake();
        _movement = GetComponent<IMovable>();
        _jump = GetComponent<IJumpable>();
        _status = GetComponent<PlayerState>();
        _grabObjects = GetComponentInChildren<GrabObjects>();
        //_swapPrototype = GetComponent<SwapPrototype>();
        _swap = GetComponent<Swap>();

    }

    protected override void Start()
    {
        base.Start();
        _swap.onChangeForm.AddListener(UpdateStats);
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
        //_swapPrototype.ChangeNextForm();
        if(_swap)
            _swap.ChangeRight();
    }

    public void SwapPrevius()
    {
        //_swapPrototype.ChangePreviusForm();
        if(_swap)
            _swap.ChangeLeft();
    }
    public void SetIsInteracting(bool isInteracting)
    {
        if(_status != null)
            _status.SetIsInteracting(isInteracting);
    }

    private void UpdateStats()
    {
        _stats = _swap.CurrentForm;
        
        if(_grabObjects)
            _grabObjects.UpdateBoxPos();
    }

}
