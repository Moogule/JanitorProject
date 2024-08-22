using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : HealthSystem
{
    protected override void Die()
    {
        //cutscene code here
        Debug.Log("Player has died");
        base.Die();
    }

}