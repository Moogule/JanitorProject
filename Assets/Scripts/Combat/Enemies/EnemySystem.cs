using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySystem : HealthSystem
{

    protected float speed;
    public Slider healthSlider;

    protected override void Start()
    {
        base.Start();
        healthSlider.maxValue = maxHealth;
        healthSlider.value = Health;
        UpdateHealthSlider();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        UpdateHealthSlider();
    }

    public override void Heal(float healAmount)
    {
        base.Heal(healAmount);
        UpdateHealthSlider();
    }

    private void UpdateHealthSlider()
    {
        if (health < maxHealth)
        {
            healthSlider.gameObject.SetActive(true);
            healthSlider.value = health;
        }
        else
        {
            healthSlider.gameObject.SetActive(false);
        }
    }

    protected override void Die()
    {
        // Custom death logic for enemies, e.g., dropping loot
        Debug.Log("Enemy has been defeated!");
        healthSlider.gameObject.SetActive(false);
        base.Die();
    }
}
