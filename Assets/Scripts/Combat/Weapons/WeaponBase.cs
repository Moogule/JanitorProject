public abstract class WeaponBase : Weapon
{
    public float damage;
    public float range;
    public float fireRate;
    
    public abstract void Attack();
    public abstract void Reload();
    public abstract void SwitchMode();

    protected bool CanAttack()
    {
        return true;
    }
}
