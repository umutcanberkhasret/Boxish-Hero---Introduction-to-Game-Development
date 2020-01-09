﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    float health;
    [SerializeField]
    float maxHealth;

    [SerializeField]
    GameObject healthBarUI;
    [SerializeField]
    Slider healthSlider;
    private void Start()
    {
        healthBarUI.SetActive(true);
        health = maxHealth;
        healthSlider.value = CalculateHealth();
    }
    private void Update()
    {
        healthSlider.value = CalculateHealth();

    }


    public void takeDamage(float damage)
    {
        if (health <= 0f)
        {
            Die();

        }
        else if (health >= 0f)
        {
            health -= damage;

        }

        if (health <= 0f)
            Die();


    }

    public void Die()
    {
        if (gameObject.tag == "Enemy")
        {
            Inventory.playerScore += 100;
            Destroy(gameObject);
        }
        if (gameObject.tag == "Player")
        {
           
            FindObjectOfType<GameManager>().EndGame();

        }
    }
 
    public float CalculateHealth()
    {
        return health / maxHealth;
    }
}
