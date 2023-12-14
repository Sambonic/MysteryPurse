using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball3 : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private PlayerStatus3 player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStatus3>();
        rb.velocity = -transform.right * speed; //move to the right according to the speed

    }
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.TakeDamage(10);
            Destroy(gameObject);
        }
    }

}
