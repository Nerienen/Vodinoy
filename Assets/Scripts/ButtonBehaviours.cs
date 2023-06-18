using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviours : MonoBehaviour
{
    public GameObject aboutText;


  public void PlayGame()
    {
        SceneManager.LoadScene("Swamp");
    }


    public void QuitGame()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }

    public void AboutShow()
    {
        if (aboutText.activeSelf)
        {
            aboutText.SetActive(false);
        }
        else
        {
            aboutText.SetActive(true);
        }
    }

}
