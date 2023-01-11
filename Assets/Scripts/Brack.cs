using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brack : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Rigidbody myRigidBody;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 500.0f;

    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        //isOnGround = controller.isGrounded;
        //if (isOnGround && velocity.y < 0)
        //{
        //    velocity.y = 0f;
        //}

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }



        //if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        //{
        //    myRigidBody.AddForce(transform.up * jumpForce);
        //}
    }

    //public float jumpForce = 1.0f;
    //public float gravity = -9.81f;
    //float velocity;

    //void FixedUpdate()
    //{
    //    velocity += gravity * Time.deltaTime;
    //    if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
    //    {
    //        velocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravity);
    //    }
    //    transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
    //}

}