using UnityEngine;

public class EmissionController : MonoBehaviour
{
    public Renderer renderer;
    public float speed = 1.0f;
    public float minExposureWeight = 0.0f;
    public float maxExposureWeight = 1.0f;

    private float currentExposureWeight = 0.0f;
    private bool increasing = true;

    void Start()
    {
        if (renderer == null)
        {
            renderer = GetComponent<Renderer>();
        }
    }

    void Update()
    {
        if (increasing)
        {
            currentExposureWeight += speed * Time.deltaTime;
            if (currentExposureWeight >= maxExposureWeight)
            {
                currentExposureWeight = maxExposureWeight;
                increasing = false;
            }
        }
        else
        {
            currentExposureWeight -= speed * Time.deltaTime;
            if (currentExposureWeight <= minExposureWeight)
            {
                currentExposureWeight = minExposureWeight;
                increasing = true;
            }
        }

        renderer.material.SetFloat("_EmissiveExposureWeight", currentExposureWeight);
    }
}
