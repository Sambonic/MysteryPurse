using UnityEngine;

public class EnemyDamage3 : MonoBehaviour
{
    public float damageAmount = 0.4f; // Amount of damage dealt to the player

    // This function is called when something enters the enemy's collider marked as trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            // Assuming the Player has a health component
            PlayerStatus3 playerHealth = collision.GetComponent<PlayerStatus3>();
            // Deal damage to the player
            playerHealth.damage(damageAmount);
            Debug.Log("Player Hit");
        }
    }
}
