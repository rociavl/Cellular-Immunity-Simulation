using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
    [Header("Settings")]
    public GameObject bacteriaPrefab;      // Normal enemy
    public GameObject superBacteriaPrefab; // The strong enemy (needs 5 shots)

    [Range(0f, 1f)]
    public float superSpawnChance = 0.01f; // 1% chance (0.01)

    public float spawnTime = 3f;
    public Vector3 spawnArea = new Vector3(20, 1, 20);

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnTime);
    }

    void SpawnEnemy()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            spawnArea.y,
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );

        Vector3 finalPosition = transform.position + randomPos;

        // --- SELECTION LOGIC ---
        GameObject enemyToSpawn;

        // Roll the dice (0.0 to 1.0)
        if (Random.value <= superSpawnChance && superBacteriaPrefab != null)
        {
            enemyToSpawn = superBacteriaPrefab; // 1% chance: Spawn the Boss
        }
        else
        {
            enemyToSpawn = bacteriaPrefab;      // 99% chance: Spawn normal
        }
        // -----------------------

        Instantiate(enemyToSpawn, finalPosition, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }
}