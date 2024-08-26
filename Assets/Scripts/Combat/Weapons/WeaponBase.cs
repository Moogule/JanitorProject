public abstract class WeaponBase : Weapon
{
    public float damage;
    public float range;
    public float fireRate;
    
    public abstract void Attack();
    public abstract void Reload(); 

    protected bool CanAttack()
    {
        return true;
    }
}
