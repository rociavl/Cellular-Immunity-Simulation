using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyFollow : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform player; // We can leave this empty in the prefab now
    public float speed = 2f;
    public float floatHeight = 1f;
    public float stopDistance = 1.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        // --- NEW CODE STARTS HERE ---
        // If the player variable is empty (null), find the object tagged as "Player" automatically
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
        // --- NEW CODE ENDS HERE ---
    }

    void FixedUpdate()
    {
        // Safety check: If player is still null (maybe you forgot the Tag), do nothing
        if (player != null)
        {
            // 1. Look at player
            Vector3 lookTarget = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(lookTarget);

            // 2. Check distance
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > stopDistance)
            {
                // 3. Move towards player using Physics
                Vector3 targetPosition = new Vector3(player.position.x, floatHeight, player.position.z);
                Vector3 direction = (targetPosition - transform.position).normalized;

                Vector3 nextPosition = transform.position + (direction * speed * Time.fixedDeltaTime);
                nextPosition.y = floatHeight;

                rb.MovePosition(nextPosition);
            }
        }
    }
}