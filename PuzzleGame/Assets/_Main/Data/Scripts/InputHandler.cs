using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Components")]
    private PlayerControls _inputActions;
    private Player _player;

    [Header("Movement")]
    public float horizontal;
    public float vertical;

    bool jump_Input;

    private Vector2 _movementInput;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        HandleInput();
        
    }

    private void FixedUpdate()
    {
       // _player.Move(horizontal, vertical;
        _player.Move(horizontal, vertical);
        
        _player.Jump();
    }

    private void LateUpdate()
    {
        jump_Input = false;
    }

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerControls();
            _inputActions.PlayerMovements.Movement.performed += inputActions => _movementInput = inputActions.ReadValue<Vector2>();
        }
        _inputActions.Enable();
    }

    private void OnDisable() => _inputActions.Disable();
    private void HandleInput()
    {
        MoveInput();
        JumpInput();
    }
    private void MoveInput()
    {
        horizontal = _movementInput.x;
        vertical = _movementInput.y;
    }

    private void JumpInput() => _inputActions.PlayerActions.Jump.performed += i => jump_Input = true;
}
