using UnityEngine;

public class LanternSway : MonoBehaviour
{
    public float maxSwaySpeed;
    public float maxSwayAngle;

    private Rigidbody lanternRigidbody;
    private HingeJoint lanternJoint;

    private void Start()
    {
        // Get a reference to the lantern's Rigidbody and HingeJoint components
        lanternRigidbody = GetComponent<Rigidbody>();
        lanternJoint = GetComponent<HingeJoint>();
    }

    private void Update()
    {
        // Generate a random angular velocity around the z-axis of the lantern's local coordinate system
        float randomSwayAngle = Random.Range(-maxSwayAngle, maxSwayAngle);
        Vector3 randomSwayVelocity = new Vector3(0, 0, randomSwayAngle) * maxSwaySpeed;

        // Apply the random angular velocity to the HingeJoint's connected Rigidbody
        lanternRigidbody.AddRelativeTorque(randomSwayVelocity);
    }
}
