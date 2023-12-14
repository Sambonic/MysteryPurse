using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth3 : MonoBehaviour
{
    private int maxHealth = 100; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy
    public PlayerStatus3 player;

    private void Start()
    {
        currentHealth = maxHealth; // Set the enemy's health to max when the game starts
    }

    void Update()
    {
        if (currentHealth <= 0)
        {

            player.addPoints(3);
            Debug.Log("Points added!");
            Die();// Call the die function when health reaches zero
            Debug.Log("Dead");
        }
    }

    // Function to decrease enemy's health when it's hit
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Decrease health by the damage amount
        Debug.Log(currentHealth);

        // Check if the enemy has run out of health
      /*  if (currentHealth <= 0)
        {
            Debug.Log("Dead");
            player.addPoints(3);
            Die();// Call the die function when health reaches zero
        }*/
    }

    // Function to handle what happens when the enemy dies
    private void Die()
    {
        // Example: Destroy the enemy object
        Debug.Log("Died");
        Destroy(gameObject);
    }
}
