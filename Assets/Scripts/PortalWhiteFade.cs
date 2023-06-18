using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class PortalWhiteFade : MonoBehaviour
{
    public Volume skyAndFogVolume;
    public float fadeDuration = 3.0f;
    private ColorAdjustments colorAdjustments;
    private float intensityTarget = 0.0f;
    private float intensityCurrent = 0.0f;
    private float fadeStartTime = 0.0f;

    private void Start()
    {
        if (skyAndFogVolume == null)
        {
            skyAndFogVolume = GameObject.FindObjectOfType<Volume>();
        }
        skyAndFogVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            intensityTarget = colorAdjustments.colorFilter.value.r + 5.0f;
            fadeStartTime = Time.time;
        }
    }

    private void Update()
    {
        float timeElapsed = Time.time - fadeStartTime;
        if (timeElapsed >= fadeDuration)
        {
            colorAdjustments.colorFilter.overrideState = false;
            return;
        }
        float t = timeElapsed / fadeDuration;
        intensityCurrent = Mathf.Lerp(colorAdjustments.colorFilter.value.r, intensityTarget, t);
        colorAdjustments.colorFilter.overrideState = true;
        colorAdjustments.colorFilter.value = new Color(intensityCurrent, intensityCurrent, intensityCurrent);
    }
}
