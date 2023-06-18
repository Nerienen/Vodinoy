using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkingPlatform : MonoBehaviour
{
    private Animator anim;

    public bool isOnPad = false;

    GameObject sinker;

    // Start is called before the first frame update
    void Start()
    {
        sinker = GetComponent<GameObject>();
        anim = GetComponent<Animator>();
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Log Collided");
        if ((other.gameObject.tag == "Player"))
        {
            anim.SetBool("isOnPad", true);
        }
        else
        {
            anim.SetBool("isOnPad", false);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("isOnPad", false);
        }
    }

}
