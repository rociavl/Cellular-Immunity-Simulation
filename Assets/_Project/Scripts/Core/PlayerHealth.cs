using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Damage Settings")]
    public float damageCooldown = 1f; // Time between damage instances
    private float lastDamageTime = -999f;

    [Header("Audio")]
    public AudioClip hurtSound;
    public AudioClip deathSound;
    private AudioSource audioSource;

    [Header("Visual Feedback")]
    public GameObject damageVignette; // Optional red screen flash

    // Events for UI
    public System.Action<int, int> OnHealthChanged; // current, max

    void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();

        // Notify UI of initial health
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        // Check cooldown to prevent rapid damage
        if (Time.time - lastDamageTime < damageCooldown) return;
        lastDamageTime = Time.time;

        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);

        // Play hurt sound
        if (hurtSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }

        // Flash damage effect
        if (damageVignette != null)
        {
            StartCoroutine(FlashDamage());
        }

        // Notify UI
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        // Check for death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    System.Collections.IEnumerator FlashDamage()
    {
        damageVignette.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        damageVignette.SetActive(false);
    }

    void Die()
    {
        // Play death sound
        if (deathSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        // Trigger game over
        if (GameManager.Instance != null)
        {
            GameManager.Instance.TriggerGameOver();
        }

        Debug.Log("Player has died!");
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }
}
