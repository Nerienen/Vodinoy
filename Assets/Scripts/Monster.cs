using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float riseDuration = 3.0f;
    public float sinkDuration = 3.0f;
    public float moveDuration = 10.0f;

    private bool isRisingOrSinking = false;
    private bool isRising = false;
    private bool isSinking = false;
    private bool isMoving = false;

    private Vector3 startingPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        // Choose a random starting position.
        startingPosition = new Vector3(
            Random.Range(-20.0f, 20.0f),
            transform.position.y,
            Random.Range(-20.0f, 20.0f)
        );

        // Set the object's position to the starting position.
        transform.position = startingPosition;

        // Start the loop by rising.
        isRisingOrSinking = true;
        isRising = true;
    }

    private void Update()
    {
        if (isRisingOrSinking)
        {
            if (isRising)
            {
                // Update the target position.
                targetPosition = transform.position + new Vector3(0, 5, 0);

                // Move the object to the target position.
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, riseDuration * Time.deltaTime);

                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    isRising = false;
                    isSinking = true;
                    isRisingOrSinking = false;
                }
            }
            else if (isSinking)
            {
                // Update the target position.
                targetPosition = transform.position - new Vector3(0, 5, 0);

                // Move the object to the target position.
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, sinkDuration * Time.deltaTime);

                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    isSinking = false;
                    isMoving = true;
                    moveDuration = 10.0f;
                }
            }
        }
        else if (isMoving)
        {
            // Update the target position.
            targetPosition = new Vector3(
                Random.Range(-20.0f, 20.0f),
                transform.position.y,
                Random.Range(-20.0f, 20.0f)
            );

            moveDuration -= Time.deltaTime;
            if (moveDuration <= 0.0f)
            {
                // Move the object to the target position.
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);



                // Restart the loop.
                gameObject.SetActive(true);
                isMoving = false;
                isRisingOrSinking = true;
                isRising = true;
            }
        }
    }
}