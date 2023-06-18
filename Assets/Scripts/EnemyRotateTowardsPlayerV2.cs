using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotateTowardsPlayerV2 : MonoBehaviour
{
   
    public GameObject playerTargetLookAt;
    public int speed = 555;
 

    // Update is called once per frame
    void Update()
    {
        var targetRotation = Quaternion.LookRotation(playerTargetLookAt.transform.position - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
