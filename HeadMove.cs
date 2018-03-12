using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMove : MonoBehaviour {

    float rotationyy, rotationxx;
    float turnSpeed;
    
	void Start () {
        rotationyy = 0f;
        rotationxx = 0f;
        turnSpeed = 100f;
	}
	
	void Update () {
        float yy = Input.GetAxisRaw("Mouse Y");

        rotationyy += yy * turnSpeed * Time.deltaTime;

        if (rotationyy > 45f)
            rotationyy = 45f;
        else if (rotationyy < -45f)
            rotationyy = -45f;

        float finalrotateyy = Mathf.Clamp(rotationyy, -45f, 45f);

        transform.localRotation = Quaternion.Euler(-finalrotateyy, 0f, 0f);
    }
}
