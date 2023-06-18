using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleSuckingPlayer : MonoBehaviour
{
    public ParticleSystem myParticleSystem;
    public AudioSource myAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damager"))
        {
            myParticleSystem.Play();
            myAudioSource.Play();
        }
    }
}
