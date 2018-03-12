using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodMouseRotate : MonoBehaviour {

    float turnSpeed;
    float Yrotation;


	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        turnSpeed = 100f;
	}
	
	void Update () {
        float MyX = Input.GetAxisRaw("Mouse X");
        float MyY = Input.GetAxisRaw("Mouse Y");
        float minAngle = -85f; float maxAngle = 90f;

        Yrotation += MyY * turnSpeed * Time.deltaTime;

        if (Yrotation < minAngle)
            Yrotation = minAngle;
        else if (Yrotation > maxAngle)
            Yrotation = maxAngle;

        float Yrolling = Mathf.Clamp(Yrotation, minAngle, maxAngle);

        transform.parent.Rotate(0f, MyX, 0f); // Right or Left
        transform.localRotation = Quaternion.Euler(-Yrolling, 0f, 0f); // Up or Down

        mouseFade();
	}

    private void mouseFade()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
        else if (Input.GetKeyDown(KeyCode.F))
            Cursor.lockState = CursorLockMode.Locked;
    }
}
