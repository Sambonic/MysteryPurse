using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{
    [SerializeField] GameObject controlUI; // Reference to the control UI game object

    bool isControlShown = false; // Flag to track if the control UI is currently visible

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isControlShown)
            {
                HideControlUI();
            }
            else
            {
                ShowControlUI();
            }
        }
    }

    void ShowControlUI()
    {
        controlUI.SetActive(true);
        isControlShown = true;
        Time.timeScale = 0f;
    }

    void HideControlUI()
    {
        controlUI.SetActive(false);
        isControlShown = false;
        Time.timeScale = 1f;
    }
}
