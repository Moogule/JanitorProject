using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : HealthSystem
{

    protected float speed;

    protected override void Die()
    {
        // Custom death logic for enemies, e.g., dropping loot
        Debug.Log("Enemy has been defeated!");
        base.Die();
    }
}
