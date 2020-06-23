using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerBody;
    
    private float xAxisClamp;
    
    void Start()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }
    
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;
        
        xAxisClamp += mouseY;
        
        if(xAxisClamp > 90.0f)
        {
            xAxisClamp = 90f;
            mouseY = 0f;
            ClampXAxisToValue(270.0f);
        }
        if(xAxisClamp < -90.0f)
        {
            xAxisClamp = -90f;
            mouseY = 0f;
            ClampXAxisToValue(90f);
        }
        
        transform.Rotate(Vector3.right * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
        
        void ClampXAxisToValue(float value)
        {
            Vector3 eulerRotation = transform.eulerAngles;
            eulerRotation.x = value;
            transform.eulerAngles = eulerRotation;
        }
    }
}
