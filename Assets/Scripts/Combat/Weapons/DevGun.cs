using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevGun : RangedWeapon
{
    
    public DevGun()
    {
        damage = 10;
        range = 100;
        fireRate = 0.5f;
        AmmoCount = 10;
        MaxAmmo = 10;
        ProjectileSpeed = 100;
    }

    public override void Attack()
    {
        if (CanAttack() && AmmoCount > 0)
        {
            base.Attack();
            AmmoCount--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
