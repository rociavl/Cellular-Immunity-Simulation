using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    public Camera playerCamera;
    public float shootRange = 100f;
    public LayerMask enemyLayer;

    [Header("Effects")]
    public GameObject deathParticle; // Particle to spawn when enemy dies

    void Update()
    {
        // Check for left mouse click
        if (Input.GetMouseButtonDown(0)) // 0 = Left Mouse Button
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create ray from center of camera
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        // Check if ray hits something
        if (Physics.Raycast(ray, out hit, shootRange, enemyLayer))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // Check if we hit an enemy
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy destroyed!");
                
                // Spawn particle effect at hit position
                if (deathParticle != null)
                {
                    Instantiate(deathParticle, hit.point, Quaternion.identity);
                }
                
                Destroy(hit.collider.gameObject);
            }
        }
    }
}