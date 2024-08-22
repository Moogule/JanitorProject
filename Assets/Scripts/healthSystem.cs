using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class healthSystem : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float regenRate;

    public UnityEvent onHealthChange;
    public UnityEvent onDeath;


    public void heal(float hGain)
    {
        if (health + hGain == health)
        { }
        else
            onHealthChange.Invoke();
        health += hGain;

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            die();
        }
        else
            onHealthChange.Invoke();
    }
    public void die()
    {
        onDeath.Invoke();
        Destroy(gameObject);
    }

}
