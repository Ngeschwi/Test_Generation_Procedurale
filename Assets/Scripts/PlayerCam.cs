using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    public float _sensX;
    public float _sensY;
    
    public Transform _orientation;
    
    private float _xRotation;
    private float _yRotation;

    private void Start() {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        
        float mouseX = Input.GetAxis("Mouse X") * _sensX * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * _sensY * Time.deltaTime;
        
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
        _yRotation += mouseX;
        
        transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        _orientation.rotation = Quaternion.Euler(0f, _yRotation, 0f);
    }
}
