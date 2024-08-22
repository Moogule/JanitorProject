using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dolla : MonoBehaviour
{
    [SerializeField] PlayerStatistics PS;

    public int dollarValue;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(1, 0, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        PS.addMoney(dollarValue);
        Debug.Log("The player now has: " + PS.dollars);
        Destroy(gameObject);
    }
}
