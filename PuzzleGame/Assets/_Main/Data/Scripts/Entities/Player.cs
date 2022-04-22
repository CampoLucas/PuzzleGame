using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Movement _movement;
    private Jump _jump;
    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    public void Move(float horizontal, float vertical)
    {
        if (_movement != null) _movement.Move(horizontal, vertical);
    }

    public void Jump()
    {
        _jump.Do();
    }
}
