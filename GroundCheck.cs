using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    bool isGround;

	void Start () {
        isGround = false;
	}
	
	void Update () {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction, Color.blue);

        if (Physics.Raycast(ray, out hit, 1f))
            isGround = true;
        else
            isGround = false;

        

	}
}
