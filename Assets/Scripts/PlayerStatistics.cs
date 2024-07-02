using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerStatistics : MonoBehaviour
{
    [SerializeField] PlayerMovement pm;
    [SerializeField] UnityEngine.UI.Slider health_slider;
    [SerializeField] TMP_Text dollar_Text;

    [Header("Player Stats")]
    public float health = 100;
    public float speed;
    public float attack_speed;
    public int dollars;

    // Start is called before the first frame update
    void Start()
    {
        health_slider.maxValue = health;
        health_slider.value = health_slider.maxValue;
    }

    private void FixedUpdate()
    {
        health_slider.value = health;
        dollar_Text.text = "$ " + dollars;
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

    public void addMoney(int amount)
    {
        dollars += amount;
    }

    public void removeMoney(int amount)
    {
        dollars -= amount;
    }

    public void die()
    {
        Destroy(gameObject);
    }
}
