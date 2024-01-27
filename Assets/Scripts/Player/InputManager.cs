using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    [HideInInspector] public Vector2 MovementXY;
    [HideInInspector] public bool IsMoving;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
    }

    void Update()
    {
        MovementXY = _moveAction.ReadValue<Vector2>();
        IsMoving = _moveAction.IsPressed();
    }
}
