using UnityEngine;
using UnityEngine.SceneManagement;

public class SwampMenuEntrance : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Tocuhed player");
            SceneManager.LoadScene("MenuSwamp 1");
        }
    }
}
