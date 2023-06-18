using UnityEngine;
using System.Collections;

public class TriggerBamboozled : MonoBehaviour
{
    public Animator treeAnimator;
    public Animator treeAnimator2;
    public Animator treeAnimator3;
    public Collider viewCollider;
    public GameObject spawner;

    public Camera mainCamera;

    public GameObject evilSpirit;

    //audio


    public AudioSource roombaSource;
    public AudioClip roombaClip;


    public AudioSource afterSource;
    public AudioClip afterClip;

    public AudioSource afterMusicSource;
    public AudioClip afterMusicClip;

    //Camera Shake

    public float duration = 0.5f;
    public float intensity = 0.1f;
    public float weakIntensity = 0.05f;

    private Vector3 originalPos;

    private void Start()
    {
        originalPos = mainCamera.transform.localPosition;
        
        
    }

    public void Shake()
    {
        StartCoroutine(DoShake(intensity));
    }

    public void ShakeWeak()
    {
        StartCoroutine(DoShake(weakIntensity));
    }

    private IEnumerator DoShake(float shakeIntensity)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = originalPos.x + Random.Range(-1f, 1f) * shakeIntensity;
            float y = originalPos.y + Random.Range(-1f, 1f) * shakeIntensity;
            float z = originalPos.z + Random.Range(-1f, 1f) * shakeIntensity;

            mainCamera.transform.localPosition = new Vector3(x, y, z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.localPosition = originalPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roombaSource.Play();
            treeAnimator.SetBool("Bamboozled", true);
            treeAnimator2.SetBool("Bamboozled", true);
            treeAnimator3.SetBool("Bamboozled", true);

            spawner.SetActive(true);
            evilSpirit.SetActive(true);
            viewCollider.enabled = false;


            Shake();
            StartCoroutine(WaitAndShakeWeak(duration)); 
           
        }
    }

    private IEnumerator WaitAndShakeWeak(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        ShakeWeak();
        afterSource.Play();
        afterMusicSource.Play();
    }
}
