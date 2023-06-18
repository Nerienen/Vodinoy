using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStepSound : MonoBehaviour
{
    public float speed = 5f;
    public AudioClip walkingSound;
    public float walkingSoundDelay = 0.5f;
    public float pitchVariation = 0.1f;
    public float myStepPitch = 1f;

    private AudioSource audioSource;
    private bool isWalking = false;
    private float lastWalkingSoundTime = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = walkingSound;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    void FixedUpdate()
    {
        if (isWalking && Time.time > lastWalkingSoundTime + walkingSoundDelay)
        {
            audioSource.pitch = myStepPitch + Random.Range(-pitchVariation, pitchVariation);
            audioSource.PlayOneShot(walkingSound);
            lastWalkingSoundTime = Time.time;
        }
    }
}
