using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlock3 : MonoBehaviour
{
    public Rigidbody2D rb;
    public ParticleSystem fireSystem;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        fireSystem.Stop();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.isKinematic = false; // Block falls when colliding with an object tagged as "Ground"
            fireSystem.Play();
            Destroy(gameObject);
        }
    }
}
