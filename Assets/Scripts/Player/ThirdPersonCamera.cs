using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    //used code from https://www.youtube.com/@davegamedevelopment
    //very good and understandable code for movement and camera
    [Header("References")]
    public Transform orientation;
    public Transform combatLookAt;
    public Transform player;
    public Transform playerObject;
    public Rigidbody rb;
    public float rot_speed = 7.0f;

    public CameraStyle currentStyle;

    public enum CameraStyle { 
        basic,
        combat
    }

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
        //rotate orientation
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDirection;
        //Debug.Log("Orientation direction is " + orientation.forward);

        if (currentStyle == CameraStyle.basic)
        {
            //rotate player object
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDirection != Vector3.zero)
            {
                playerObject.forward = Vector3.Slerp(playerObject.forward, inputDirection.normalized, Time.deltaTime * rot_speed);
            }
        }

        else if(currentStyle == CameraStyle.combat)
        {
            Vector3 combatDirection = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = combatDirection.normalized;

            playerObject.forward = combatDirection.normalized;
        }

    }
}
