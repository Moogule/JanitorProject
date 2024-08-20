using UnityEngine.Events;
using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    [SerializeField]
    protected float health;
    [SerializeField]
    protected float maxHealth;
    [SerializeField]
    protected float regenRate;

    public UnityEvent onHealthChange;
    public UnityEvent onDeath;

    public float Health => health;
    public float MaxHealth => maxHealth;

    protected virtual void Start()
    {
        health = maxHealth; 
    }

    public virtual void Heal(float healAmount)
    {
        if (healAmount > 0)
        {
            health = Mathf.Min(health + healAmount, maxHealth);
            onHealthChange.Invoke();
        }
    }

    public virtual void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            health -= damage;
            onHealthChange.Invoke();

            if (health <= 0)
            {
                Die();
            }
        }
    }

    protected virtual void Die()
    {
        onDeath.Invoke();
        Destroy(gameObject); 
    }

    protected virtual void Update()
    {
        if (regenRate > 0 && health < maxHealth)
        {
            Heal(regenRate * Time.deltaTime);
        }
    }

    public virtual void SetHealth(float health)
    {
        this.health = health;
        onHealthChange.Invoke();
    }

    public virtual void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        onHealthChange.Invoke();
    }


}