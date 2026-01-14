using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    // How strong the player pushes objects
    public float pushPower = 2.0f;

    // This function is automatically called when the CharacterController hits a collider
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // 1. Check if the object we hit has a Rigidbody
        Rigidbody body = hit.collider.attachedRigidbody;

        // 2. If no Rigidbody or it's Kinematic (static), do nothing
        if (body == null || body.isKinematic)
        {
            return;
        }

        // 3. We don't want to push objects down (into the floor), only sideways
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // 4. Calculate push direction (from player to object)
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // 5. Apply the push!
        body.velocity = pushDir * pushPower;
    }
}
