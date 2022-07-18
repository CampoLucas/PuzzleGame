using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Components")]
    private PlayerControls _inputActions;
    private Player _player;

    [Header("Movement")]
    private float _horizontal;
    private float _vertical;
    private float _moveAmount;

    private bool _jumpInput;
    private bool _grabInput;
    private bool _swapRightInput;
    private bool _swapLeftInput;
    private bool _actionInput;
    private bool _nextLevel;
    private bool _prevLevel;

    private Vector2 _movementInput;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if(_player.IsClimbing)
            return;
        HandleInput();
        
        _player.UpdateAnimationValues(_horizontal, _vertical);
    }

    private void FixedUpdate()
    {
        if (_player.IsClimbing)
        {
            _player.ClimbLadder();
            return;
        }
        _player.Move(new Vector3(_horizontal, _vertical));
    }

    private void LateUpdate()
    {

        _jumpInput = false;
        _grabInput = false;

        _swapLeftInput = false;
        _swapRightInput = false;

        _actionInput = false;

        _nextLevel = false;
        _prevLevel = false;
    }

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerControls();
            _inputActions.PlayerMovements.Movement.performed += inputActions => _movementInput = inputActions.ReadValue<Vector2>();

            _inputActions.PlayerActions.Jump.performed += i => _jumpInput = true;
            _inputActions.PlayerActions.Grab.performed += i => _grabInput = true;
            _inputActions.PlayerActions.SwapL.performed += i => _swapLeftInput = true;
            _inputActions.PlayerActions.SwapR.performed += i => _swapRightInput = true;
            _inputActions.PlayerActions.Action.performed += i => _actionInput = true;
            
            _inputActions.PlayerActions.NextLevel.performed += i => _nextLevel = true;
            
            _inputActions.PlayerActions.PrevLevel.performed += i => _prevLevel = true;
        }
        _inputActions.Enable();
    }

    private void OnDisable() => _inputActions.Disable();
    private void HandleInput()
    {
        MoveInput();
        JumpInput();
        GrabInput();
        SwapInput();
        ActionInput();
        NextLevelInput();
        PrevLevelInput();
    }
    private void MoveInput()
    {
        _horizontal = _movementInput.x;
        _vertical = _movementInput.y;
        
        _moveAmount = Mathf.Clamp01(Mathf.Abs(_horizontal) + Mathf.Abs(_vertical));
    }

    private void JumpInput()
    {
        if (_jumpInput) _player.Jump();
    }

    private void GrabInput()
    {
        if (_grabInput)
        {
            _player.GrabObject();
            _player.PressButton();
        }
    }

    private void SwapInput()
    {
        if (_swapLeftInput) _player.SwapPrevius();
        else if (_swapRightInput)  _player.SwapNext();
    }

    private void ActionInput()
    {
        if(_actionInput) _player.Action();
    }

    private void NextLevelInput()
    {
        if(_nextLevel) GameManager.instance.LoadLevel();
    }
    private void PrevLevelInput()
    {
        if(_prevLevel) GameManager.instance.LoadPrevLevel();
    }
}
