using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //if (Application.platform == RuntimePlatform.Android)
        {

            Debug.Log("Quit");
            Application.Quit();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void MainM()
    {
        SceneManager.LoadScene("Main");
    }
}
