using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedAudioPlay : MonoBehaviour
{
    public float delayTime = 0.5f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(DelayedPlay(delayTime));
    }

    IEnumerator DelayedPlay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        audioSource.Play();
    }
}
