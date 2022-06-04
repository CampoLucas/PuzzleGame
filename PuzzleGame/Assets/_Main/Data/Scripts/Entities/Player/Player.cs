using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player : Stats
{
    private IMovable _movement;
    private IJumpable _jump;
    
    private PlayerState _status;
    private GrabObjects _grabObjects;
    
    //private SwapPrototype _swapPrototype;
    private Swap2 _swap2;
    
    public bool IsGrounded => _status.IsGrounded;
    public bool IsInteracting => _status.IsInteracting;

    private void Awake()
    {
        _movement = GetComponent<IMovable>();
        _jump = GetComponent<IJumpable>();
        _status = GetComponent<PlayerState>();
        _grabObjects = GetComponentInChildren<GrabObjects>();
        //_swapPrototype = GetComponent<SwapPrototype>();
        _swap2 = GetComponent<Swap2>();

    }

    private void Start()
    {
        _swap2.onChangeForm.AddListener(UpdateStats);
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
        if(_swap2)
            _swap2.ChangeRight();
    }

    public void SwapPrevius()
    {
        //_swapPrototype.ChangePreviusForm();
        if(_swap2)
            _swap2.ChangeLeft();
    }
    public void SetIsInteracting(bool isInteracting)
    {
        if(_status != null)
            _status.SetIsInteracting(isInteracting);
    }

    private void UpdateStats()
    {
        _stats = _swap2.CurrentForm;
    }

}
