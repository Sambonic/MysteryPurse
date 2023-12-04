using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box3 : MonoBehaviour
{
    public int hitPoints = 3; // Number of hits required to break the box

    private bool isTouching;
    private float touchTimer;
    public float destroyDelay = 1f;
    public PlayerStatus3 player;

    private void Update()
    {
        if (isTouching)
        {
            touchTimer += Time.deltaTime;
            // Check if the touch duration exceeds the destroyDelay
            if (touchTimer >= destroyDelay)
            {
                DestroyBox();
            }
        }
        else
        {
            // Reset the timer if the player is not touching the box
            touchTimer = 0f;
        }
        
    }

    public void TakeHit()
    {
        hitPoints--; // Reduce hit points by 1

        if (hitPoints <= 0)
        {
            BreakBox(); // Break the box if hit points reach zero or below
        }
    }

    private void BreakBox()
    {
        // Add any effects or actions when the box breaks
        Debug.Log("Box broken!");

        if (gameObject.CompareTag("Coins"))
        {
            player.addPoints(1);
        }

        Destroy(gameObject); // Destroy the box object
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
        // Check if the player is no longer colliding with the box
        if (collision.CompareTag("Player"))
        {
            isTouching = false;
        }
    }

    private void DestroyBox()
    {
        // Destroy the box game object
        Destroy(gameObject);
    }
}
