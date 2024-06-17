using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //used code from https://www.youtube.com/@davegamedevelopment
    //very good and understandable code for movement and camera
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObject;
    public Rigidbody rb;
    public float rot_speed = 7.0f;

    public float player_speed = 5f;
    public float groundDrag;

    [Header("Ground Detection")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponentInParent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    void Update()
    {
        //ground check (said zestily)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + .2f, whatIsGround);

        //drag controller
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        //rotate orientation
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;

        //rotate player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDirection = orientation.forward *verticalInput + orientation.right * horizontalInput;

        if(inputDirection != Vector3.zero)
        {
            playerObject.forward = Vector3.Slerp(playerObject.forward, inputDirection.normalized, Time.deltaTime * rot_speed);
        }

    }

    private void FixedUpdate()
    {
        //movePlayer();
        speedControl();
    }

    private void movePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");//POTENTIAL AREA OF LAG I THINK
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = orientation.forward *verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized *  player_speed * 10f , ForceMode.Force);
    }

    void speedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVelocity.magnitude > player_speed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized*player_speed; 
            rb.velocity = new Vector3(limitedVelocity.x ,rb.velocity.y, limitedVelocity.z);
        }
    }
}
