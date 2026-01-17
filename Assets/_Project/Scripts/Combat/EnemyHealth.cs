using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 1;
    private int currentHealth;

    [Header("Audio")]
    public AudioClip deathSound;
    [Range(0f, 1f)]
    public float deathVolume = 1.0f;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    void Die()
    {
        if (deathSound != null)
        {
            // Instead of PlayClipAtPoint (which is always 3D), we use a custom helper function
            PlaySound2D(deathSound, deathVolume);
        }
    }

    // --- NEW HELPER FUNCTION ---
    void PlaySound2D(AudioClip clip, float volume)
    {
        // 1. Create a temporary empty GameObject
        GameObject soundObject = new GameObject("TempAudio");

        // 2. Add an AudioSource component to it
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();

        // 3. Configure the AudioSource
        audioSource.clip = clip;
        audioSource.volume = volume;

        // IMPORTANT: Set Spatial Blend to 0 (2D). 
        // 0.0 = 2D (Sound plays equally everywhere)
        // 1.0 = 3D (Sound fades with distance)
        audioSource.spatialBlend = 0f;

        // 4. Play the sound
        audioSource.Play();

        // 5. Destroy the object automatically after the clip finishes
        // clip.length is the duration of the sound in seconds
        Destroy(soundObject, clip.length);
    }
}