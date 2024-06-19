using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatistics : MonoBehaviour
{
    [SerializeField] PlayerMovement pm;
    [SerializeField] Slider health_slider;

    [Header("Player Stats")]
    public float health = 100;
    public float speed;
    public float attack_speed;

    // Start is called before the first frame update
    void Start()
    {
        health_slider.maxValue = health;
        health_slider.value = health_slider.maxValue;
    }

    private void FixedUpdate()
    {
        health_slider.value = health;
    }

    public void takeDamage(float damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
            health_slider.value = health - damage;
        }
        else
        {
            health_slider.value = 0;
            die();
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }
}
