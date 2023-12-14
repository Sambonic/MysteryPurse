using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack4 : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask Boxes;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Attack();
        }
    }

    /*public int damageAmount = 20; // Amount of damage player's attack causes

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with an enemy
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>(); // Get the EnemyHealth component of the collided enemy

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount); // Apply damage to the enemy
            }

            // You can add effects, sound, or other actions when the enemy is hit here
        }
    }*/

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Collider2D[] hitBoxes = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, Boxes);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth4>().TakeDamage(20);
           // Debug.Log("Enemy Hit");
        }
        foreach (Collider2D objects in hitBoxes)
        {
            objects.GetComponent<Box4>().TakeHit();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
