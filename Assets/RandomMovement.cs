using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 0.2f;
    public float noiseScale = 1.0f;
    public float rotationSpeed = 0.5f;
    public float transitionSpeed = 1.0f;
    public string playerTag = "Player";
    public Vector3 transitionPosition = new Vector3(125f, 25f, 164f);

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private float noiseOffset;
    private bool isTransitioning = false;

    void Start()
    {
        // Set the initial target position to the current position
        startPosition = transform.position;
        targetPosition = transform.position;

        // Generate a random noise offset
        noiseOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        if (!isTransitioning)
        {
            // Update the target position based on Perlin noise
            float x = Mathf.PerlinNoise(Time.time * moveSpeed + noiseOffset, 0) * 2.0f - 1.0f;
            float y = Mathf.PerlinNoise(0, Time.time * moveSpeed + noiseOffset) * 2.0f - 1.0f;
            float z = Mathf.PerlinNoise(Time.time * moveSpeed + noiseOffset, Time.time * moveSpeed + noiseOffset) * 2.0f - 1.0f;
            Vector3 noise = new Vector3(x, y, z) * noiseScale;
            targetPosition = startPosition + noise;

            // Move towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);

            // Update the target rotation
            Vector3 direction = (targetPosition - transform.position).normalized;
            targetRotation = Quaternion.LookRotation(direction, Vector3.up);

            // Rotate towards the target rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            StartCoroutine(TransitionToPosition(transitionPosition));
        }
    }

    IEnumerator TransitionToPosition(Vector3 position)
    {
        isTransitioning = true;
        Vector3 startingPosition = transform.position;
        Quaternion startingRotation = transform.rotation;
        float elapsedTime = 0;

        while (elapsedTime < transitionSpeed)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPosition, position, elapsedTime / transitionSpeed);
            transform.rotation = Quaternion.Lerp(startingRotation, Quaternion.LookRotation(position - startingPosition), elapsedTime / transitionSpeed);
            yield return null;
        }

        isTransitioning = false;
    }
}
