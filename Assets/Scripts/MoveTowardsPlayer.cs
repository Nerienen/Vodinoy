using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;
    public float speed = 5f;
    public float descentSpeed = 1f;
    public float descentDistance = 10f;

    private bool isDescending = false;
    private Collider objectCollider; // reference to the collider component of the object

    private void Start()
    {
        player = GameObject.Find("PlayerControllerFPS");
        playerTransform = player.transform;

        objectCollider = GetComponent<Collider>(); // get the collider component of the object
    }

    private void Update()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        direction.y = 0f;

        // move towards the player, except when it's descending
        if (!isDescending)
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        //is within vision range?
        if (Vector3.Distance(transform.position, playerTransform.position) <= descentDistance)
        {
            isDescending = true;
        }

        // if object is descending, move it downwards 
        if (isDescending)
        {
            transform.position -= Vector3.up * descentSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VisionRange"))
        {
            isDescending = true;

            // deactivate the collider of the object
            objectCollider.enabled = false;
        }
    }
}
