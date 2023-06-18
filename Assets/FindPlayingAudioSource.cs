using UnityEngine;

public class FindPlayingAudioSource : MonoBehaviour
{
    private AudioSource[] allAudioSources;

    private void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    private void Update()
    {
        foreach (var audioSource in allAudioSources)
        {
            if (audioSource.isPlaying)
            {
                Debug.Log(audioSource.name + " is currently playing.");
            }
        }
    }
}
