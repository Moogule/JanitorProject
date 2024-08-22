using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : WeaponBase
{
    public int AmmoCount { get; set; }
    public int MaxAmmo { get; set; }
    public int ProjectileSpeed { get; set; }

    public override void Reload()
    {
        // Implement reload logic specific to ranged weapons
    }

    public override void Attack()
    {
        if (CanAttack() && AmmoCount > 0)
        {
            // Implement ranged attack logic
            AmmoCount--;
        }
    }
}
