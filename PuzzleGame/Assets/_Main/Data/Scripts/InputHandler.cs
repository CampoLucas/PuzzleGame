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
    bool grab_Input;
    bool swapRight_Input;
    bool swapLeft_Input;

    private Vector2 _movementInput;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {

        HandleInput();
        _player.Move(new Vector3(horizontal, vertical));
        if (jump_Input) _player.Jump();
        if (grab_Input) _player.GrabObject();
        //if (swap_Input) _player.SwapPlayer();
        if (swapLeft_Input) _player.SwapPrevius();
        else if (swapRight_Input)  _player.SwapNext();
    }

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {

        jump_Input = false;
        grab_Input = false;

        swapLeft_Input = false;
        swapRight_Input = false;

    }

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerControls();
            _inputActions.PlayerMovements.Movement.performed += inputActions => _movementInput = inputActions.ReadValue<Vector2>();

            _inputActions.PlayerActions.Jump.performed += i => jump_Input = true;
            _inputActions.PlayerActions.Grab.performed += i => grab_Input = true;
            _inputActions.PlayerActions.SwapL.performed += i => swapLeft_Input = true;
            _inputActions.PlayerActions.SwapR.performed += i => swapRight_Input = true;
        }
        _inputActions.Enable();
    }

    private void OnDisable() => _inputActions.Disable();
    private void HandleInput()
    {
        MoveInput();
        //JumpInput();
        //GrabInput();
        //SwapInput();
    }
    private void MoveInput()
    {
        horizontal = _movementInput.x;
        vertical = _movementInput.y;
    }

    //private void JumpInput() => _inputActions.PlayerActions.Jump.performed += i => jump_Input = true;

    //private void GrabInput() => _inputActions.PlayerActions.Grab.performed += i => grab_Input = true;

    //private void SwapInput() => _inputActions.PlayerActions.Swap.performed += i => swapLeft_Input = true;
}
