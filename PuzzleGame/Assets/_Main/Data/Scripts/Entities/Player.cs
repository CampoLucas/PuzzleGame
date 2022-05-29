using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Stats
{
    private IMovable _movement;
    private IJumpable _jump;
    private PlayerState _status;
    private GrabObjects _grabObjects;
    private Swap _swapPlayer;
    private SwapPrototype _swapPrototype;
    private void Awake()
    {
        _movement = GetComponent<IMovable>();
        _jump = GetComponent<IJumpable>();
        _status = GetComponent<PlayerState>();
        _grabObjects = GetComponentInChildren<GrabObjects>();
        _swapPlayer = GetComponent<Swap>();
        _swapPrototype = GetComponent<SwapPrototype>();
        
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

    public bool isGrounded() => _status.IsGrounded();

    public void GrabObject()
    {
        if (_grabObjects != null)
            _grabObjects.GrabObject();
    }

    //public void SwapPlayer()
    //{

    //    if (_swapPlayer)
    //    {
    //        _swapPlayer.SwapPlayer();
    //    }
    //}

    public void DisableGravity(bool isGravity)
    {
        if(_jump != null)
            _jump.DisableGravity(isGravity);
        if(_movement != null)
            _movement.DisableGravity(isGravity);
    }

    public void SwapNext()
    {
        _swapPrototype.ChangeNextForm();
    }

    public void SwapPrevius()
    {
        Debug.Log("Entra swap");
        _swapPrototype.ChangePreviusForm();
    }

}
