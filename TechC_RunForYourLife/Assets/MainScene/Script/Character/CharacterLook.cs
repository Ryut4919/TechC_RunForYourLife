﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterLook : MonoBehaviour {
    [SerializeField] private string mouseXInputName, mouseYInputName;
    //マウスの移動速度
    [SerializeField] private float mouseSensitivity;
    [SerializeField]
    CharacterControl _chara;
    [SerializeField] Transform playerBody;

    private float XClamp;
    private bool StopCameraFollow;

    // Use this for initialization
    void Awake () {
        LockCursor();
        XClamp = 0.0f;
        StopCameraFollow = false;
    }

    void LockCursor()
    {
        //マウスを隠す
        Cursor.lockState = CursorLockMode.Locked;
        
    }
    // Update is called once per frame
    void Update ()
    {
        if (_chara.FpsMode)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StopCameraFollow = !StopCameraFollow;
                Cursor.visible = true;
            }
        }

        if (_chara.TpsMode)
        {

        }
        
        if (!StopCameraFollow)
        {
            //カメラの回転
            CameraRotation();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) *mouseSensitivity* Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        XClamp += mouseY;

        if (XClamp > 90.0f)
        {
            //上向きの最大範囲
            XClamp = 90.0f;
            mouseY = 0.0f;
            XAxisRotationToValue(270.0f);
        }
        else if (XClamp < -90.0f)
        {
            //下向きの最大範囲
            XClamp = -90.0f;
            mouseY = 0.0f;
            XAxisRotationToValue(90.0f);
        }
        //カメラの回転
        transform.Rotate(Vector3.left * mouseY);
        //プレイヤーの回転
        playerBody.Rotate(Vector3.up, mouseX);
    }

    private void XAxisRotationToValue(float Value)
    {
        Vector3 eulerAngle = transform.eulerAngles;
        eulerAngle.x = Value;
        transform.eulerAngles = eulerAngle;
    }


}
