using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerHealthSystem healthSystem;
    [SerializeField] UnityEngine.UI.Slider healthBar;
    [SerializeField] TMP_Text dollarText;

    [Header("Player Stats")]
    public float speed;
    public float attack_speed;
    public int dollars;


    void Start()
    {
        if (healthSystem != null)
        {
            healthBar.maxValue = healthSystem.MaxHealth;
            healthBar.value = healthSystem.Health;
            healthSystem.onHealthChange.AddListener(UpdateHealthUI);
        }
    }

    private void UpdateHealthUI()
    {
        healthBar.value = healthSystem.Health;
    }

    private void FixedUpdate()
    {
        dollarText.text = "$ " + dollars;
    }

    public void AddMoney(int amount)
    {
        dollars += amount;
    }

    public void RemoveMoney(int amount)
    {
        dollars -= amount;
    }

}
