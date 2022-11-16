using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{   
	public float maxSpeed;
	public float normalSpeed = 10.0f;
	public float sprintSpeed = 40.0f;
	public float maxSprint = 5.0f;
	float sprintTimer;

    float rotation = 0.0f;
    float camRotation = 0.0f;
    float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;
    GameObject cam;
    Rigidbody myRigidBody;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 500.0f;

    Animator myAnim;
    
    void Start()
    {
        myAnim = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
		
		sprintTimer = maxSprint;
		
		cam = GameObject.Find("Main Camera");
        myRigidBody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
        myAnim.SetBool("isOnGround", isOnGround);

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myAnim.SetTrigger("jumped");
            myRigidBody.AddForce(transform.up * jumpForce);
        }

		if (Input.GetKey(KeyCode.LeftShift) && sprintTimer > 0.0f)
		{
			maxSpeed = sprintSpeed;
			sprintTimer = sprintTimer - Time.deltaTime;
		} else
		{
			maxSpeed = normalSpeed;
			if (Input.GetKey(KeyCode.LeftShift) == false)
			{
				sprintTimer = sprintTimer + Time.deltaTime;
			}
		}

		sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);

        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed + (transform.right * Input.GetAxis ("Horizontal") * maxSpeed));
        myRigidBody.velocity = new Vector3(newVelocity.x, myRigidBody.velocity.y, newVelocity.z);

        myAnim.SetFloat("speed", newVelocity.magnitude);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(-camRotation, 0.0f, 0.0f));
    }
}
