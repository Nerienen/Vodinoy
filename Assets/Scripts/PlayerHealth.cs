using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Damager"))
        {

            Debug.Log("Player damaged");
            currentHealth--;
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("Swamp");
            }
        }


        if (other.CompareTag("Death"))
        {
            currentHealth = currentHealth - 3;

        }

    }
}
