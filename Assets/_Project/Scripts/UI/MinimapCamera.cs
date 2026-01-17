using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Settings")]
    public float height = 50f;
    public float smoothSpeed = 10f;

    void LateUpdate()
    {
        if (player == null) return;

        // Follow player position from above
        Vector3 targetPosition = new Vector3(
            player.position.x,
            player.position.y + height,
            player.position.z
        );

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    }
}
