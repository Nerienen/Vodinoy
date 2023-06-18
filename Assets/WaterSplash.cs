using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    public AudioSource splash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            // Play the audio source with a random pitch variation
            float pitch = Random.Range(0.85f, 1.15f);
            splash.pitch = pitch;
            splash.Play();
        }
    }
}
