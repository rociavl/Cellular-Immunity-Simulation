using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour
{
    [Header("Audio")]
    public AudioClip shootSound;
    private AudioSource audioSource;

    [Header("Shooting Settings")]
    public Camera playerCamera;
    public Transform gunMuzzle; // NEW: The physical position where the bullet starts (the gun barrel)
    public float shootRange = 100f;
    public LayerMask enemyLayer;

    [Header("Effects")]
    public GameObject deathParticle;
    public LineRenderer bulletTrailPrefab;

    [Range(0.01f, 1f)]
    public float trailDuration = 0.1f; // NEW: How long the line stays visible (0.1 is usually good)

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
        // 1. Play Sound
        if (shootSound != null && audioSource != null)
        {
            // Randomize pitch slightly for realism (optional but sounds better)
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.PlayOneShot(shootSound);
        }

        // 2. Calculate Raycast (Still from the camera center for accuracy)
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit, shootRange, enemyLayer))
        {
            targetPoint = hit.point;

            // Hit logic
            if (hit.collider.CompareTag("Enemy"))
            {
                if (deathParticle != null)
                {
                    Instantiate(deathParticle, hit.point, Quaternion.identity);
                }
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            targetPoint = ray.origin + ray.direction * shootRange;
        }

        // 3. Draw Trail
        if (bulletTrailPrefab != null)
        {
            // NEW: Now we use the gunMuzzle position instead of the camera position
            // If gunMuzzle is not assigned, we fallback to camera position to avoid errors
            Vector3 startPos = (gunMuzzle != null) ? gunMuzzle.position : playerCamera.transform.position;

            StartCoroutine(SpawnTrail(startPos, targetPoint));
        }
    }

    IEnumerator SpawnTrail(Vector3 startPos, Vector3 endPos)
    {
        LineRenderer trail = Instantiate(bulletTrailPrefab);

        trail.SetPosition(0, startPos);
        trail.SetPosition(1, endPos);

        // NEW: Wait for the duration variable we set in the Inspector
        yield return new WaitForSeconds(trailDuration);

        Destroy(trail.gameObject);
    }
}