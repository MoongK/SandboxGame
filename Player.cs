using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    bool onGround;
    float jumpPressure;
    float minJump;
    float maxJumpPressure;

    Rigidbody rb;
    Animator anim;

	void Start ()
    {
        onGround = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}

    void Update()
    {
        if (onGround)
        {
            if (Input.GetButton("Jump"))
            {
                if (jumpPressure < maxJumpPressure)
                    jumpPressure += Time.deltaTime * 10f;
                else
                    jumpPressure = maxJumpPressure;

                anim.SetFloat("jumpPressure", jumpPressure + minJump);
                anim.speed = 1f + (jumpPressure / 10f);
            }

            else
            {
                if (jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minJump;
                    rb.velocity = new Vector3(0f, jumpPressure, 0f);
                    jumpPressure = 0f;
                    onGround = false;
                    anim.SetBool("onGround", onGround);
                    anim.SetFloat("jumpPressure", 0f);
                    anim.speed = 1f;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            anim.SetBool("onGround", onGround);
        }
    }
}
