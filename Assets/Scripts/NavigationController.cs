using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{
    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToLevelOneScene()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToLevelTwoScene()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToLevelThreeScene()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToLevelFourScene()
    {
        SceneManager.LoadScene(4);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
