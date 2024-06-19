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

    public float player_speed = 5f;
    public float groundDrag;

    private bool readyToJump = true;
    public float jumpForce;
    public float jumpCooldown;//in seconds
    public float airMultiplier;//speed change for in air like in csgo

    [Header("KeyBinds")]
    public KeyCode jump = KeyCode.Space;

    [Header("Ground Detection")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        //ground check (said zestily)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + .2f, whatIsGround);
        Debug.Log("Is the player grounded");

        //drag controller
        if (isGrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;


    }

    private void MyInput()
    {
        if (Input.GetKey(jump) && isGrounded && readyToJump)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump),jumpCooldown);
        }
    }

    private void FixedUpdate()
    {
        MyInput();
        movePlayer();
        speedControl();
    }

    private void Jump()
    {
        //reset the y velocity 
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void movePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = orientation.forward *verticalInput + orientation.right * horizontalInput;

        if(isGrounded)
            rb.AddForce(moveDirection.normalized *  player_speed * 10f , ForceMode.Force);
        else if(!isGrounded)
            rb.AddForce(moveDirection.normalized * player_speed * 10f * airMultiplier, ForceMode.Force);
    }

    void speedControl()
    {
        //this is the currect horizontal velocity of the player
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //basically if the player is going faster than we want, just force the velocity to be what we want it to be
        if(flatVelocity.magnitude > player_speed)
        {
            //this is the current velocity that has been normalized and then multiplied by the player speed
            //basically turning this into 1 * player_speed since normalizing a value changes it into a value between 0 and 1.
            Vector3 limitedVelocity = flatVelocity.normalized*player_speed; 

            //applying the velocity
            rb.velocity = new Vector3(limitedVelocity.x ,rb.velocity.y, limitedVelocity.z);
        }
    }
}
