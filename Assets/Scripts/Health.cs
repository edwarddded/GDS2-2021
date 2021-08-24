using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int currentHealth;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
            Die();
    }

    void TakeDamage(int damage)
    {
        // This is to prevent the player's health from going into a negative value when taking damage
        if((currentHealth - damage) < 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= damage;
        }
    }

    void Die()
    {
        // 
    }
}
