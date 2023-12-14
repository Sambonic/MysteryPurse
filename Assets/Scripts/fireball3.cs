using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball3 : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private bool Hit = false;
    private PlayerStatus3 player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStatus3>();
        rb.velocity = -transform.right * speed; //move to the right according to the speed

    }
    void Update()
    {
        if (Hit)
        {
            hitPlayer();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Hit = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the player is no longer colliding with the box
        if (collision.CompareTag("Player"))
        {
            Hit = false;
        }
    }

    private void hitPlayer()
    {
        player.health = player.health - 30;
    }
}
