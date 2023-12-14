using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

   /* public void openSettings()
    {
        SceneManager.LoadScene(0); //Put the scene number of the Options Scene
    }*/

    public void QuitGame()
    {
        Application.Quit();
    }
}
