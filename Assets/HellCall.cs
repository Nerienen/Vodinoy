using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HellCall : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject fogObject;
    public float cameraFOV = 170.0f;
    public float transitionTime = 5.0f;
    public float waitTime = 3.0f;
    public string hell;

    private bool isTransitioning = false;
    private float timer = 0.0f;

    public AudioSource hellCall;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTransitioning)
        {
            isTransitioning = true;
            StartCoroutine(FOVTransition());
            hellCall.Play();
        }
    }

    IEnumerator FOVTransition()
    {
        float startFOV = mainCamera.fieldOfView;
        float endFOV = cameraFOV;
        float timeElapsed = 0.0f;

        while (timeElapsed < transitionTime)
        {
            timeElapsed += Time.deltaTime;
            float t = timeElapsed / transitionTime;
            mainCamera.fieldOfView = Mathf.Lerp(startFOV, endFOV, t);
            yield return null;
        }

        // Activate the fog object
        fogObject.SetActive(true);

        // Wait for waitTime seconds
        yield return new WaitForSeconds(waitTime);

        // Load the next scene
        SceneManager.LoadScene(hell);
    }
}
