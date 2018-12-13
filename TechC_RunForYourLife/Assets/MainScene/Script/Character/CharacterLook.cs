using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLook : MonoBehaviour {
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] Transform playerBody;

    private float XClamp;
    
    // Use this for initialization
    void Awake () {
        LockCursor();
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update ()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) *mouseSensitivity* Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        XClamp += mouseY;

        if (XClamp > 80.0f)
        {
            XClamp = 80.0f;
            mouseY = 0.0f;
            XAxisRotationToValue(270.0f);
        }
        else if (XClamp < -50.0f)
        {
            XClamp = -50.0f;
            mouseY = 0.0f;
            XAxisRotationToValue(90.0f);
        }
        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up, mouseX);
    }

    private void XAxisRotationToValue(float Value)
    {
        Vector3 eulerAngle = transform.eulerAngles;
        eulerAngle.x = Value;
        transform.eulerAngles = eulerAngle;
    }
}
