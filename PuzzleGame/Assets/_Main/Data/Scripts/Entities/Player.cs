using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Stats
{
    private Movement _movement;
    private Jump _jump;
    private PlayerState _status;
    private GrabObjects _grabObjects;
    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _jump = GetComponent<Jump>();
        _status = GetComponent<PlayerState>();
        _grabObjects = GetComponentInChildren<GrabObjects>();
    }

    public void Move(float horizontal, float vertical) => _movement?.Move(horizontal, vertical);

    public void Jump() =>_jump?.Do();

    public bool isGrounded()
    {
        return _status.IsGrounded();

    }

    public void GrabObject(bool input)
    {
        if (_grabObjects != null)
            _grabObjects.GrabObject(input);
    }


}
