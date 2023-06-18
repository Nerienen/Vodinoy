using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30f; // degrees per second
    public float minRotation = 5f;
    public float maxRotation = 60f;
    private float currentRotation = 5f;
    private bool increasingRotation = true;

    private void Update()
    {
        float targetRotation = increasingRotation ? maxRotation : minRotation;
        float step = rotationSpeed * Time.deltaTime;
        currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, step);
        transform.rotation = Quaternion.Euler(0f, currentRotation, 0f);

        if (Mathf.Abs(currentRotation - targetRotation) < 0.1f)
        {
            increasingRotation = !increasingRotation;
        }
    }
}
