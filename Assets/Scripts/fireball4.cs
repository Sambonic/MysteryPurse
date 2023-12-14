using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball4 : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private bool Hit = false;
    private PlayerStats4 player;
    private float rotateSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats4>();
        rb.velocity = -transform.right * speed; //move to the right according to the speed

    }
    void Update()
    {
        if (this.tag == "sandal")
        {
            transform.Rotate(0, 0, rotateSpeed);
        }
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
        player.damage(0.3f);
    }
}
