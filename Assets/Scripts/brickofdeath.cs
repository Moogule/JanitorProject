using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickofdeath : MonoBehaviour
{
    [Header("Testshitlololol")]
    [SerializeField] BoxCollider BC;
    [SerializeField] PlayerStatistics playerStats;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("YO THIS SHIT HAPPENING B IM COLLIDING WITH ANOTHER GAMEOBJECT!! HELP");
        playerStats.takeDamage(10);
    }
}
