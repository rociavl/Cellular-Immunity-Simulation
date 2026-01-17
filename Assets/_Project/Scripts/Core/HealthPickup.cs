using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [Header("Healing")]
    public int healAmount = 25;

    [Header("Visual Effects")]
    public float rotateSpeed = 50f;
    public float bobSpeed = 2f;
    public float bobHeight = 0.3f;

    [Header("Audio")]
    public AudioClip pickupSound;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Rotate for visual effect
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);

        // Bob up and down
        float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Only heal if player is damaged
            if (playerHealth != null && playerHealth.currentHealth < playerHealth.maxHealth)
            {
                // Play pickup sound
                if (pickupSound != null)
                {
                    AudioSource.PlayClipAtPoint(pickupSound, transform.position);
                }

                playerHealth.Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
