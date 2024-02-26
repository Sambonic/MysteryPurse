using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShielding3 : MonoBehaviour
{
    public Animator animator;
    public GameObject Shield;
    private EdgeCollider2D shieldCollider;
    // private bool isShielding = false;
    public float pushForce = 10f;

    void Start()
    {
        animator = GetComponent<Animator>();
        shieldCollider = Shield.GetComponent<EdgeCollider2D>();
        shieldCollider.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
           // isShielding = true;
            shielding();
        }
        else 
        {
           // isShielding = false;
            stopShielding();
        }
    }

    private void shielding()
    {
        if (animator != null)
        {
            animator.SetTrigger("Shield");
            shieldCollider.enabled = true; // Enable the edge collider
        }
    }
    private void stopShielding()
    {
        if (animator != null)
        {
            animator.ResetTrigger("Shield");
            shieldCollider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("fireball"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = (other.transform.position - transform.position).normalized;
                rb.velocity = direction * pushForce; // Push the fireball in the opposite direction
            }

            Destroy(other.gameObject); // Destroy the fireball on collision
        }
    }
}
