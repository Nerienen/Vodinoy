using UnityEngine;
using System.Collections;

public class DeafenPlayer : MonoBehaviour
{
    public float duration = 10f; 
    public float deafVolume = 0f; 
    private float originalVolume; 
    private bool isDeafened = true; 

    private void Start()
    {
        originalVolume = AudioListener.volume; 
        AudioListener.volume = deafVolume;
        StartCoroutine(GradualVolumeChange(originalVolume, duration)); 
    }

    private IEnumerator GradualVolumeChange(float targetVolume, float duration)
    {
        float startVolume = deafVolume;
        float startTime = Time.time;
        float endTime = startTime + duration;

        while (Time.time < endTime)
        {
            float elapsed = Time.time - startTime;
            float t = Mathf.Clamp01(elapsed / duration);
            float newVolume = Mathf.Lerp(startVolume, targetVolume, t);
            AudioListener.volume = newVolume;

            yield return null;
        }

        AudioListener.volume = targetVolume;
        isDeafened = false;
    }

    
    public bool IsDeafened()
    {
        return isDeafened;
    }
}
