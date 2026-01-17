using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip shootSound;
    private AudioSource audioSource;

    [Header("Shooting Settings")]
    public Camera playerCamera;
    public Transform gunMuzzle; // The physical position where the bullet starts
    public float shootRange = 100f;
    public LayerMask enemyLayer;

    [Header("Effects")]
    public GameObject deathParticle; // Effect spawned ONLY when enemy dies
    public LineRenderer bulletTrailPrefab; // The visual line of the bullet

    [Range(0.01f, 1f)]
    public float trailDuration = 0.1f; // How long the trail is visible

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // 1. AUDIO: Play shoot sound
        if (shootSound != null && audioSource != null)
        {
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.PlayOneShot(shootSound);
        }

        // 2. PHYSICS: Raycast calculation
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Vector3 targetPoint;

        bool hasHit = Physics.Raycast(ray, out hit, shootRange, enemyLayer);

        if (hasHit)
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.origin + ray.direction * shootRange;
        }

        // 3. VISUALS: Draw the bullet trail
        if (bulletTrailPrefab != null)
        {
            Vector3 startPos = (gunMuzzle != null) ? gunMuzzle.position : playerCamera.transform.position;
            StartCoroutine(SpawnTrail(startPos, targetPoint));
        }

        // 4. LOGIC: Handle hit
        if (hasHit)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                // A) Health Logic
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(1);

                    // If enemy is still alive, we STOP here.
                    // No particles, no destruction. Just damage.
                    if (!enemyHealth.IsDead())
                    {
                        return;
                    }
                }

                // --- DEATH SECTION (Only happens if HP <= 0) ---

                // B) Spawn Death Effect (Blood/Explosion)
                // Now this ONLY happens when the enemy actually dies
                if (deathParticle != null)
                {
                    Instantiate(deathParticle, hit.point + (hit.normal * 0.2f), Quaternion.LookRotation(hit.normal));
                }

                // Add score for kill
                if (GameManager.Instance != null)
                {
                    // Super bacteria worth more points
                    int points = (enemyHealth != null && enemyHealth.maxHealth > 1) ? 50 : 10;
                    GameManager.Instance.AddScore(points);
                }

                Debug.Log("Enemy destroyed!");

                // C) Check for splitting ability
                BacteriaSplitter splitter = hit.collider.GetComponent<BacteriaSplitter>();
                if (splitter != null)
                {
                    splitter.TryToSplit();
                }

                // D) Destroy the game object
                Destroy(hit.collider.gameObject);
            }
        }
    }

    IEnumerator SpawnTrail(Vector3 startPos, Vector3 endPos)
    {
        LineRenderer trail = Instantiate(bulletTrailPrefab);

        trail.SetPosition(0, startPos);
        trail.SetPosition(1, endPos);

        yield return new WaitForSeconds(trailDuration);

        Destroy(trail.gameObject);
    }
}