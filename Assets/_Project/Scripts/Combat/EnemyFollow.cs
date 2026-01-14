using UnityEngine;

// This line ensures that if you add this script, Unity automatically adds a Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class EnemyFollow : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform player;
    public float speed = 2f;
    public float floatHeight = 1f;
    public float stopDistance = 1.5f;

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to this enemy
        rb = GetComponent<Rigidbody>();

        // Safety settings: Ensure gravity doesn't mess with our floating logic
        rb.useGravity = false;
        // Prevent the enemy from falling over or spinning when hitting others
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // We use FixedUpdate for Physics calculations (Rigidbody)
    void FixedUpdate()
    {
        if (player != null)
        {
            // 1. ROTATION (Visuals)
            // We keep looking at the player using Transform because it doesn't affect physics collisions
            Vector3 lookTarget = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(lookTarget);

            // 2. DISTANCE CHECK
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > stopDistance)
            {
                // Calculate the direction towards the player
                Vector3 targetPosition = new Vector3(player.position.x, floatHeight, player.position.z);
                Vector3 direction = (targetPosition - transform.position).normalized;

                // 3. MOVEMENT (Physics)
                // Instead of "transform.position =", we use "MovePosition"
                // This respects collisions. If there is another enemy in the way, it won't pass through.
                Vector3 nextPosition = transform.position + (direction * speed * Time.fixedDeltaTime);

                // Force the Y position to stay at floatHeight
                nextPosition.y = floatHeight;

                rb.MovePosition(nextPosition);
            }
        }
    }
}