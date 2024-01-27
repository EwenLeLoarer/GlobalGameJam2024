using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        // _moveAction = _playerInput.actions["Move"];
    }

    void Update()
    {
    }
}
