using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralLoop : MonoBehaviour
{
    public float radius = 2.0f;
    public float loopHeight = 1.0f;
    public float speed = 2.0f;
    public float noiseStrength = 0.1f;
    public float noiseFrequency = 1.0f;

    private float _angle;
    private float _time;
    private Vector3 _lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        _angle = 0.0f;
        _time = 0.0f;
        _lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new position on the spiral
        _angle += speed * Time.deltaTime;
        _time += Time.deltaTime;
        float x = Mathf.Cos(_angle) * radius;
        float y = _time * loopHeight;
        float z = Mathf.Sin(_angle) * radius;
        Vector3 position = new Vector3(x, y, z);

        // Add some noise to the movement
        Vector3 noise = new Vector3(
            Mathf.PerlinNoise(0.0f, Time.time * noiseFrequency) - 0.5f,
            Mathf.PerlinNoise(1.0f, Time.time * noiseFrequency) - 0.5f,
            Mathf.PerlinNoise(2.0f, Time.time * noiseFrequency) - 0.5f
        ) * noiseStrength;

        // Update the object's position and rotation
        transform.position = _lastPosition + position + noise;
        transform.rotation = Quaternion.LookRotation(position + noise - _lastPosition);

        // Save the last position for the next frame
        _lastPosition = transform.position;
    }
}
