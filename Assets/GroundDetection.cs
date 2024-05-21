using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{


    public bool grounded = true;

    public bool getGrounded()
    {
        return grounded;
    }

    //is grouned detector
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "ground")
        {
            grounded = true;
            Debug.Log("Player is grounded");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "ground")
        {
            grounded = false;
            Debug.Log("Player is not grounded");
        }
    }
}
