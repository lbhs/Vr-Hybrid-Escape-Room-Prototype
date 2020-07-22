using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatScreenCameraController : MonoBehaviour
{
    public float mouseSensitivity = 1f;

    //The transform of the player so the entire player will rotate with the camera
    public Transform playerTransform;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Screen.fullScreen = true;
    }
    
    void LateUpdate()
    {
        //calculates the angles
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRotation -= mouseY;

        //clamp rotation so it has limits
        xRotation = Mathf.Clamp(xRotation, -90f, 90);

        //apples rotations
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
