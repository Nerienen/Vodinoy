using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 1f;
    public float acceleration = 0.1f;

    private void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        float step = speed * Time.fixedDeltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Gradually increase the speed
        speed += acceleration * Time.fixedDeltaTime;
    }
}
