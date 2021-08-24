using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //This health script should be reusable on all GameObjects that need health
    //Please let me (Kevin) know if there is any issue with the script / code

    private int currentHealth;
    public int maxHealth;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        UpdateHealthBar();
        if (currentHealth <= 0)
            Die();
    }

    void TakeDamage(int damage)
    {
        // This is to prevent the GameObject's health from going into a negative value when taking damage
        if((currentHealth - damage) < 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= damage;
        }

        UpdateHealthBar();
    }

    void Heal(int healAmount)
    {
        // This is to prevent the GameObject's health from going above the maximum health
        if((currentHealth + healAmount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healAmount;
        }

        UpdateHealthBar();
    }

    void Die()
    {
        // 
    }

    private void UpdateHealthBar()
    {
        // Only the player has a health bar so a null check is needed
        // To prevent the game from breaking
        if(healthBar != null)
        healthBar.fillAmount = (float) currentHealth / maxHealth;
    }
}
