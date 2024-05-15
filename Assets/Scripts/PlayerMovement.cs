using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float player_speed =5f;
    public float player_deceleration = 0.9f;

    public GameObject player;
    Rigidbody rb;

    private float horizontalInput;
    private float verticalInput;
    Vector3 movement_Direction;

    

    private void FixedUpdate()
    {
        if (movement_Direction != Vector3.zero)
        {
            //rb.AddForce(movement_Direction * player_speed * Time.fixedDeltaTime, ForceMode.Impulse);
            rb.velocity = movement_Direction * player_speed;
        }
        else
            rb.velocity = Vector3.zero;
        
        
        rb.rotation = Quaternion.Euler(0f, rb.rotation.eulerAngles.y, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HA: " + horizontalInput + ", VA: " + verticalInput);
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        movement_Direction = new Vector3(horizontalInput, 0f,verticalInput).normalized;
    }
}
