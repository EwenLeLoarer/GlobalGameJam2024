using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _useItemAction;
    [HideInInspector] public Vector2 MovementXY;
    [HideInInspector] public bool IsMoving;

    public event Action OnUseItem;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _useItemAction = _playerInput.actions["UseItem"];
    }

    void OnEnable()
    {
        _useItemAction.performed += UseItem;
    }

    void OnDisable()
    {
        _useItemAction.performed -= UseItem;
    }

    void UseItem(InputAction.CallbackContext context)
    {
        OnUseItem?.Invoke();
    }

    void Update()
    {
        MovementXY = _moveAction.ReadValue<Vector2>();
        IsMoving = _moveAction.IsPressed();
    }
}
