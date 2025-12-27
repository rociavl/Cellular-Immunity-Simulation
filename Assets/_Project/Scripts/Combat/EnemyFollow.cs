using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform player;
    public float speed = 2f;
    public float floatHeight = 1f;
    public float stopDistance = 1.5f; // Stop this far from player

    void Update()
    {
        if (player != null)
        {
            // Calculate distance to player
            float distance = Vector3.Distance(transform.position, player.position);
            
            // Only move if far enough away
            if (distance > stopDistance)
            {
                // Get player position but at enemy's current height
                Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
                
                // Calculate direction (only horizontal)
                Vector3 direction = (targetPosition - transform.position).normalized;
                
                // Move toward player
                transform.position += direction * speed * Time.deltaTime;
            }
            
            // Lock height
            transform.position = new Vector3(transform.position.x, floatHeight, transform.position.z);
            
            // Always look at player
            Vector3 lookTarget = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(lookTarget);
        }
    }
}