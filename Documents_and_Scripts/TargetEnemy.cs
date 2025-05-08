using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Health Bar")]
    public EnemyHealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemy hit! Current health: " + currentHealth);

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);  // Updates the bar
        }

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy destroyed!");
        Destroy(gameObject);
    }
}
1
