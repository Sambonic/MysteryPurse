using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth4 : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy
    public PlayerStats4 player;

    private void Start()
    {
        currentHealth = maxHealth; // Set the enemy's health to max when the game starts
    }

    // Function to decrease enemy's health when it's hit
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Decrease health by the damage amount
        Debug.Log("Enemy Hit");

        // Check if the enemy has run out of health
        if (currentHealth <= 0)
        {
            player.addPoints(3);
            Die();// Call the die function when health reaches zero
        }
    }

    // Function to handle what happens when the enemy dies
    void Die()
    {
        // Example: Destroy the enemy object
        Destroy(gameObject);
    }
}
