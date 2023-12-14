using UnityEngine;

public class EnemyDamage4 : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage dealt to the player

    // This function is called when something enters the enemy's collider marked as trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            PlayerStats4 playerHealth = collision.GetComponent<PlayerStats4>();
            playerHealth.TakeDamage(damageAmount);
            Debug.Log("Player Hit");
        }
    }
}
