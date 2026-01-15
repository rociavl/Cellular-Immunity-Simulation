using UnityEngine;

public class BacteriaSplitter : MonoBehaviour
{
    [Header("Split Settings")]
    public GameObject bacteriaPrefab; // The enemy to spawn
    [Range(0f, 1f)]
    public float splitChance = 0.5f; // 0.5 = 50% chance to split

    // We call this function just before the enemy dies
    public void TryToSplit()
    {
        // Random.value returns a number between 0.0 and 1.0
        // If the random number is smaller than our chance, we split!
        if (Random.value <= splitChance)
        {
            SpawnCopy(new Vector3(0.5f, 0, 0.5f));  // Offset slightly Right/Forward
            SpawnCopy(new Vector3(-0.5f, 0, -0.5f)); // Offset slightly Left/Back
        }
    }

    void SpawnCopy(Vector3 offset)
    {
        if (bacteriaPrefab != null)
        {
            // Calculate spawn position relative to current position
            Vector3 spawnPos = transform.position + offset;

            // Spawn the new bacteria
            Instantiate(bacteriaPrefab, spawnPos, transform.rotation);
        }
    }
}