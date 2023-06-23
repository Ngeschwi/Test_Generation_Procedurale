using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    private CharacterController _playerCharacterController;
    private float _moveSpeed;
    public float _walkSpeed;
    public float _runSpeed;
    public float _jumpForce;
    public float _gravity;
    public Vector3 _moveDirection;
    public bool _canMove = true;
    private float _horizontalInput;
    private float _verticalInput;
    
    private void Start() {
        
        _playerCharacterController = GetComponent<CharacterController>();
    }

    private void Update() {
        
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        
        Vector3 moveDirection = transform.forward * _verticalInput + transform.right * _horizontalInput;
        
        if (Input.GetKey(KeyCode.LeftControl)) {
            _moveSpeed = _runSpeed;
        } else {
            _moveSpeed = _walkSpeed;
        }
        
        _moveDirection = new Vector3(
            moveDirection.x * _moveSpeed,
            _moveDirection.y,
            moveDirection.z * _moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && _playerCharacterController.isGrounded) {
            _moveDirection.y = _jumpForce;
        }

        if (!_playerCharacterController.isGrounded) {
            _moveDirection.y -= _gravity * Time.deltaTime;
        }
        
        if (_moveDirection.x != 0 || _moveDirection.z != 0) {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(new Vector3(_moveDirection.x, 0, _moveDirection.z)), 
                0.15f);
        }
    }
    
    private void FixedUpdate() {
        
        if (_canMove) {
            _playerCharacterController.Move(_moveDirection * Time.deltaTime);
        }
    }
}
