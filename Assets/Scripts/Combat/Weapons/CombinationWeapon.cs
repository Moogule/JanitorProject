public abstract class CombinationWeapon : WeaponBase
{
    private bool isRangedMode;

    public override void SwitchMode()
    {
        isRangedMode = !isRangedMode;
        // Optionally, you could trigger some visual or audio feedback to indicate mode switch
    }

    public override void Attack()
    {
        if (CanAttack())
        {
            if (isRangedMode)
            {
                PerformRangedAttack();
            }
            else
            {
                PerformMeleeAttack();
            }
        }
    }

    protected abstract void PerformRangedAttack();
    protected abstract void PerformMeleeAttack();

    public override void Reload()
    {
        if (isRangedMode)
        {
            // Implement reload logic for ranged attack
        }
    }
}