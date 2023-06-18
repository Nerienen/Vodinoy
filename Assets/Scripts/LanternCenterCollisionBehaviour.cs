using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternCenterCollisionBehaviour : MonoBehaviour
{


    //When collectable lightball arrives at lantern center, setActive false,
   

    public Collider lanternCenter;
    public GameObject spawnableLight;
    public GameObject lanternLight;

    //activate stable lightball in lantern and add time to light duration
    //also this light strenght lerps down as time passes. Track states active and not active.

    public LightController lightController;

    private AudioSource audioSource;
    private AudioClip audioClip;

    private void Start()
    {
        
        lightController = GetComponent<LightController>();
        audioSource = GetComponent<AudioSource>();
        audioClip = GetComponent<AudioClip>();
    }

    public void OnTriggerEnter(Collider other)


    {

        Debug.Log("OnTriggerEnter called");
        if (other.CompareTag("LightBall"))
        {
            audioSource.Play();
            // call CollectBall function 
            lightController.CollectBall();


            Debug.Log("Collided with ball");
            other.gameObject.SetActive(false);
            spawnableLight.SetActive(true);
            lanternLight.SetActive(true);
        }

    }

}
