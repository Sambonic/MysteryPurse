using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;
    public static bool isPaused = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausemenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Pause()
    {
        pausemenu.SetActive(true);
        AudioListener.pause = true;
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        pausemenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
