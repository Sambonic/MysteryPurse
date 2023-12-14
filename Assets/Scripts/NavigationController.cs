using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{
   /* public void GoToMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }*/
   //Reorganize after all the scens have been finsihed

    public void GoToLevelOneScene()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToLevelTwoScene()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToLevelThreeScene()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToGameOverScene()
    {
        SceneManager.LoadScene(3);
    }
    /*public void Quit()
    {
        Application.Quit();
    }*/

}
