using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

       // if (gameObject.GetComponent<ThirdPersonController>().GetComponent<Fli>().enabled == true)
        { }

        //if (gameObject.GetComponent<ThirdPersonController>().GetComponent<Flight>().enabled == true)
        { }


    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;


    }

    public void LoadMenu()
    {
       SceneManager.LoadScene("Main");
    }

    public void Quitgame()
    { //if (Application.platform == RuntimePlatform.Android)
        {

            Debug.Log("Quit");
            Application.Quit();
        }
    }
}

