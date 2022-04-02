using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerControls _inputActions;
    //private Movement _movement;
    //private "Jump"/"Action?" creo que seria mejor hacer scripts separados para el salto del cubo, la propolsion de la bola y el giro de la piramide

    Vector2 movementInput;

    private void Awake()
    {
        //... = GetComponent<...>();
    }

    private void Update()
    {
        HandleAllInputs();
    }

    private void OnEnable()
    {
        if(_inputActions == null)
        {
            _inputActions = new PlayerControls();
            _inputActions.PlayerMovements.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
        }

        _inputActions.Enable();
    }

    private void OnDisable() => _inputActions.Disable();

    private void HandleAllInputs()
    {
        MoveInput();
    }

    private void MoveInput()
    {
        /*
        horizontal = movementInput.x;
        vertical = movementInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));*/
    }

    private void ActionInput()
    {
        //inputActions.PlayerActions.Action.performed += i => //Bool = true;
    }
}
