using UnityEngine;

public class HealthPickupSpawner : MonoBehaviour
{
    [Header("Spawning")]
    public GameObject healthPickupPrefab;
    public float spawnInterval = 15f;
    public float initialDelay = 10f;
    public float spawnRadius = 30f;
    public float spawnHeight = 1.5f;

    [Header("Limits")]
    public int maxPickupsInScene = 3;

    void Start()
    {
        // Don't auto-start - wait for IntroManager to call StartSpawning()
    }

    public void StartSpawning()
    {
        InvokeRepeating(nameof(TrySpawnHealthPickup), initialDelay, spawnInterval);
    }

    void TrySpawnHealthPickup()
    {
        // Don't spawn if too many pickups exist
        int currentPickups = FindObjectsByType<HealthPickup>(FindObjectsSortMode.None).Length;
        if (currentPickups >= maxPickupsInScene) return;

        SpawnHealthPickup();
    }

    void SpawnHealthPickup()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnRadius, spawnRadius),
            spawnHeight,
            Random.Range(-spawnRadius, spawnRadius)
        );

        Instantiate(healthPickupPrefab, randomPos, Quaternion.identity);
    }

    // Visual debug in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnRadius * 2, 2f, spawnRadius * 2));
    }
}
