using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Movement _movement;
    private Jump _jump;
    PlayerController _status;
    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _jump = GetComponent<Jump>();
        _status = GetComponent<PlayerController>();
    }

    public void Move(float horizontal, float vertical) => _movement?.Move(horizontal, vertical);

    public void Jump() =>_jump?.Do();

    public bool isGrounded()
    {
        return _status.IsGrounded();

    }


}
