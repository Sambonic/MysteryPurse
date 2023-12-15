using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RespawnPlayer()
    {
        PlayermotionLevel2 player2 = FindObjectOfType<PlayermotionLevel2>();
        Playermotion player1 = FindObjectOfType<Playermotion>();

        if (player2 != null)
        {
            player2.transform.position = CurrentCheckpoint.transform.position;
        }
        else if(player1 != null)
        {
            player1.transform.position = CurrentCheckpoint.transform.position;
        }
    }
   
}
