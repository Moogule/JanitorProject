using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFacePlayer : MonoBehaviour
{
    public TMP_Text TMP;
    public GameObject gm; //item meant to get picked up
    public GameObject cam;//player camera
    public Canvas canvas;//item's canvas
    public LayerMask whatIsPlayer;

    public void FixedUpdate()
    {
        /*if (Physics.CheckSphere(gm.transform.position,5,whatIsPlayer))
        {
            canvas.enabled = true;
            if(TMP != null && Input.GetKey(KeyCode.E))
            {
                ChangeTextColor(Color.yellow );
            }
            else
                ChangeTextColor(Color.white);
        }
        else
            canvas.enabled = false;*/

        Vector3 camDir = cam.transform.position - canvas.transform.position;
        transform.LookAt(cam.transform.position);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,transform.rotation.eulerAngles.y, 0);
        //Quaternion.LookRotation(camDir.normalized, new Vector3(0,camDir.y).normalized);
    }

    public void ChangeTextColor(Vector4 colorVal)
    {
        TMP.color = colorVal;
    }
}
