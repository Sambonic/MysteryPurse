using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigHealth3 : MonoBehaviour
{
    public PlayerStatus3 player;
    private bool isTouching;


    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            if (Input.GetButton("Submit"))
            {
                increaseHealth();
                destroy();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouching = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouching = false;
        }
    }

    private void increaseHealth()
    {
        player.increaseHealth(0.5f);
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
