using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodMover : MonoBehaviour
{
    Animator anim;
    Vector3 MoveDirection;
    Rigidbody rg;

    bool isGround;
    public float speed = 10f;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rg = GetComponent<Rigidbody>();
        isGround = true;
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        MoveDirection = new Vector3(h, 0f, v).normalized;
        MoveDirection = transform.TransformDirection(MoveDirection);

        transform.position = Vector3.MoveTowards(transform.position, transform.position + MoveDirection, speed * Time.deltaTime);

        if (isGround)
        {
            if (Input.GetButtonDown("Jump"))
                rg.AddForce(Vector3.up * 300f);
        }

        //Ray GroundChecker = new Ray(transform.position, Vector3.down);
        //RaycastHit hit;
        //Debug.DrawRay(GroundChecker.origin, GroundChecker.direction, Color.blue);

        //if (Physics.Raycast(GroundChecker, out hit, 1f))
        //    isGround = true;
        //else
        //    isGround = false;

        if (rg.velocity.y != 0f)
            isGround = false;
        else
            isGround = true;

        print("velocity.y : " + rg.velocity.y);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 4f, Color.red);


    }
}
