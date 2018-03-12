using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBlock : MonoBehaviour {

    public GameObject block;

	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 4f))
        {
            print(hit.transform.name);
            if (hit.collider.CompareTag("Block"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Destroy(hit.transform.gameObject);
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    Instantiate(block, hit.transform.position + hit.normal, Quaternion.identity);
                }
            }
        }
	}
}
