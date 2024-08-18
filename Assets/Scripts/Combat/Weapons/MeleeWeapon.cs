public abstract class MeleeWeapon : WeaponBase
{
    public override void Reload() { }

    public override void Attack()
    {
        if (CanAttack())
        {
            // Implement melee attack logic
        }
    }
}
