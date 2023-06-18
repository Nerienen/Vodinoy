using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class LightController : MonoBehaviour
{
    public float lightIntensityBase = 5.0f;
    public float lightTimeBase = 30.0f;
    public float lightIntensityMax = 100.0f;
    public float lightTimeMax = 120.0f;
    public float lightIntensity;
    public float lightTime;
    public Light light;
    public bool isLit = false;
    public GameObject spawnableLight;
    public Material lightMaterial;
    public float emissionBase = 0.0f;
    public float emissionMax = 1.0f;

    public AudioSource lightOutSource;
    public AudioClip lightOutClip;


    public AudioSource fireOutSource;
    public AudioClip fireOutClip;

    public AudioSource fireDuringLitSource;
    public AudioClip fireDuringLitClip;
    public ParticleSystem lightOutPPS;

    private bool hasPlayedAudio = false;

    private void Start()
    {
        lightIntensity = lightIntensityBase;
        lightTime = lightTimeBase;
    }

    private void Update()
    {
        if (isLit && lightTime > 0.0f)
        {
            lightTime -= Time.deltaTime;
            light.intensity = Mathf.Lerp(0.0f, lightIntensity, lightTime / lightTimeBase);
            lightMaterial.SetColor("_EmissiveColor", Color.white * Mathf.Lerp(emissionBase, emissionMax, lightTime / lightTimeBase));


            if (lightTime <= 5.0f)
            {
                if (!hasPlayedAudio)
                {
                    lightOutSource.Play();
                    hasPlayedAudio = true;
                    lightOutPPS.Play();
                }
            }


            // check if lightTime has passed
            if (lightTime <= 1.0f)
            {
                if (!hasPlayedAudio)
                {
                    fireOutSource.PlayOneShot(fireOutClip);
                    hasPlayedAudio = true;
                }
            }

            // if the fire during lit audio is not playing, start it
            if (!fireDuringLitSource.isPlaying)
            {
                fireDuringLitSource.clip = fireDuringLitClip;
                fireDuringLitSource.loop = true;
                fireDuringLitSource.Play();
            }
        }
        else
        {
            // stop the light out audio and particle system if it's playing
            if (lightOutSource.isPlaying)
            {
                lightOutSource.Stop();
            }

            if (lightOutPPS.isPlaying)
            {
                lightOutPPS.Stop();
            }

            // stop the fire during lit audio if it's playing
            if (fireDuringLitSource.isPlaying)
            {
                fireDuringLitSource.Stop();
            }

            isLit = false;
            spawnableLight.SetActive(false);
            lightTime = 0.0f;
            light.intensity = 0.0f;
            lightMaterial.SetColor("_EmissiveColor", Color.black);
        }
    }

    public void CollectBall()
    {
        lightIntensity += lightTimeBase;
        if (lightIntensity > lightIntensityMax)
        {
            lightIntensity = lightIntensityMax;
        }

        lightTime += lightTimeBase;
        if (lightTime > lightTimeMax)
        {
            lightTime = lightTimeMax;
        }

        if (!isLit)
        {
            isLit = true;
            light.intensity = lightIntensity;
            lightMaterial.SetColor("_EmissiveColor", Color.white * emissionBase);
            hasPlayedAudio = false;
        }
    }
}
