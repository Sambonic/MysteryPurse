using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayermotionLevel2 player2 = FindObjectOfType<PlayermotionLevel2>();
            if (player2 != null)
            {
                if (FindObjectOfType<PlayerCollections>().GetBone())
                {
                    Debug.Log("Proceed");
                }
                else
                {
                    Debug.Log("I ain't talkin' unless you get me bone");
                }
            }
        }
    }
}
