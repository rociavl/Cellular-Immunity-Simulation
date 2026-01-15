using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 1; // 1 for normal, 5 for Super
    private int currentHealth;

    void OnEnable()
    {
        // Reset health when the enemy is created
        currentHealth = maxHealth;
    }

    // This function is called by the PlayerShooting script
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }

    // Check if the enemy is dead
    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}