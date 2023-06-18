using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class TentacleAnimRig : MonoBehaviour
{
    public Rig tentacleRig;
    public float weightSpeed = 0.5f;
    int attack_ID;
    public bool playerInRange;
    public Transform playerTransform;

    public LightController lightController;
    public bool isLit;

    Animator animator;

    public AudioSource splush;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Get the transform of the gameobject with "Player" tag
        lightController = GameObject.FindGameObjectWithTag("LightManager").GetComponent<LightController>();
        splush = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        InvokeRepeating("CheckPlayerInRange", 0f, 0.5f); // Invoke CheckPlayerInRange() function every 1 second
    }

    void CheckPlayerInRange()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < 20f)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
        isLit = lightController.isLit;

        if (playerInRange && !isLit)
        {
            // weight 1
            attack_ID = 1;
        }
        else if (playerInRange && isLit)
        {
            // weight 0
            attack_ID = 2;
            splush.Play();
        }
        else if (!playerInRange)
        {
           
            tentacleRig.weight = Mathf.MoveTowards(tentacleRig.weight, 0.1f, weightSpeed * Time.deltaTime);
            
        }   

        animator.SetBool("playerInRange", playerInRange);
        animator.SetBool("isLit", isLit);

        if (attack_ID == 1)
        {
            tentacleRig.weight = Mathf.MoveTowards(tentacleRig.weight, 0.7f, weightSpeed * Time.deltaTime);
            if (tentacleRig.weight == 0.7f) attack_ID = 0;
        }

        if (attack_ID == 2)
        {
            tentacleRig.weight = Mathf.MoveTowards(tentacleRig.weight, 0f, weightSpeed * Time.deltaTime);
            if (tentacleRig.weight == 0f) attack_ID = 0;
        }
    }
}
