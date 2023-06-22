using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    
    public Transform _playerPosition;
    public float _mouseSensitivity;
    private float _cameraVerticalRotation;

    private void Start() {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {

        float inputX = Input.GetAxis("Mouse X") * _mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * _mouseSensitivity;
        
        _cameraVerticalRotation -= inputY;
        _cameraVerticalRotation = Mathf.Clamp(_cameraVerticalRotation, -90, 90);
        transform.localEulerAngles = Vector3.right * _cameraVerticalRotation;
        
        _playerPosition.Rotate(Vector3.up * inputX);
    }
}
