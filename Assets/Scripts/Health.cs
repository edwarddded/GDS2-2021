using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //This health script should be reusable on all GameObjects that need health
    //Please let me (Kevin) know if there is any issue with the script / code

    public int currentHealth;
    public int maxHealth = 20;

    public Healthbar healthbar;

    [Header("Add the splatter effect")]
    [SerializeField] private Image RedSplatterImage = null;
    [SerializeField] private Image RedEffect = null;
    [SerializeField] private float hurtTimer = 0.3f;
    [SerializeField] private Animator PlayerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
        RedSplatterImage.enabled = false;
        RedEffect.enabled = false;
        PlayerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        UpdateHealthBar();
        if (currentHealth <= 0)
            Die();
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(2);
        }
    }
    public void TakeDamage(int damage)
    {
        // This is to prevent the GameObject's health from going into a negative value when taking damage

        StartCoroutine(HurtFlash());
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

    public void Heal(int healAmount)
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
        StartCoroutine(PlayerDie());
        
    }
    IEnumerator PlayerDie()
    {
        PlayerAnimator.SetTrigger("Die");
        PlayerMovement movement = GetComponent<PlayerMovement>();
        movement.enabled = false;
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(5);
    }
    IEnumerator HurtFlash()
    {
        PlayerAnimator.SetTrigger("IsHit");
        RedSplatterImage.enabled = true;
        RedEffect.enabled = true;
        yield return new WaitForSeconds(hurtTimer);
        RedSplatterImage.enabled = false;
        RedEffect.enabled = false;
    }
    private void UpdateHealthBar()
    {
        // Only the player has a health bar so a null check is needed
        // To prevent the game from breaking
        if (healthbar != null)
            healthbar.setHealth(currentHealth);    
    }
}
