using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private InputManager _inputManager;
    private CharacterController _characterController;
    private Transform _mainCameraTransform;
    private Animator _animator;

    [SerializeField] float _speed = 1f;

    void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _characterController = GetComponent<CharacterController>();
        _mainCameraTransform = Camera.main.transform;

        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        _animator.SetFloat(Animator.StringToHash("X"), _inputManager.MovementXY.x);
        _animator.SetFloat(Animator.StringToHash("Y"), _inputManager.MovementXY.y);
        Vector2 movementXY = (_inputManager.MovementXY * _speed) * Time.deltaTime;
        Vector3 movement = Quaternion.AngleAxis(_mainCameraTransform.eulerAngles.y, Vector3.up) * new Vector3(movementXY.x, 0f, movementXY.y);

        _characterController.Move(movement);

        //_characterController.isGrounded
    }

    
}
