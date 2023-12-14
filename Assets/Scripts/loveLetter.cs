using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loveLetter : MonoBehaviour
{
    [SerializeField] GameObject letter;
    public PlayerStatus3 player;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void showLetter()
    {
        letter.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        letter.SetActive(false);
        Time.timeScale = 1f;
    }
}
