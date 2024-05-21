using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float player_speed = 5f;
    public float player_deceleration = 0.9f;
    public float jump_height = 20f;

    public GroundDetection GD; //Script in the player rigidbody that returns if the player is grounded
    public GameObject player;
    public GameObject cam;
    Rigidbody rb;
    

    Vector3 movement_Direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponentInChildren<Rigidbody>();
        //cam = player.GetComponentInChildren<Camera>();
    }


    // Update is called once per frame
    void Update()
    {

        //gets the input direction from the predefined set buttons in project settings and sets them as a vector
        movement_Direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * player_speed;// a value between -1 and 1 for the two axis
        movement_Direction.y = rb.velocity.y;
        rb.velocity = movement_Direction;//setting the rb velocity to the movement direction * the speed of the player

        rb.rotation = Quaternion.Euler(0f, rb.rotation.eulerAngles.y, 0f);//this quaternion thing somehow prevents the player from tipping over lol no one rlly explained it to me
        Debug.Log("The player is grounded: " + GD.getGrounded());

        //jump
        //TODO need to add jump cool down 
        if(Input.GetAxis("Jump") >0 && GD.getGrounded())
        {
            rb.AddForce(0f, jump_height,0f);
        }


        //CAMERA MOVEMENT
        //cam.transform.position = rb.position.x;

    }
}
