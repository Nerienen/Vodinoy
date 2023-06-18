using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollector : MonoBehaviour
{
    //if getting into area of lightballs lightballs go towards lantern

    public float lightBallSpeed;

    public Transform Target;

   
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LightBall"))
        {
            // Debug.Log("Touched light ball");

            
            GameObject lightBall = other.gameObject;

           
            StartCoroutine(MoveTowardsTarget(lightBall.transform));

        }
    }
    



    private IEnumerator MoveTowardsTarget(Transform lightBallTransform)
    {
        while (Vector3.Distance(lightBallTransform.position, Target.position) > 0.01f)
        {
            lightBallTransform.position = Vector3.Lerp(lightBallTransform.position, Target.position, lightBallSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
