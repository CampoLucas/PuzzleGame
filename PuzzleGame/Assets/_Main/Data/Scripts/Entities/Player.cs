using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Stats
{
    private Movement _movement;
    private Jump _jump;
    PlayerState _status;
    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _jump = GetComponent<Jump>();
        _status = GetComponent<PlayerState>();
    }

    public void Move(float horizontal, float vertical) => _movement?.Move(horizontal, vertical);

    public void Jump() =>_jump?.Do();

    public bool isGrounded()
    {
        return _status.IsGrounded();

    }


}
