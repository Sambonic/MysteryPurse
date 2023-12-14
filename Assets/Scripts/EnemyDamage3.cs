using UnityEngine;

public class EnemyDamage3 : MonoBehaviour
{
    private int damageAmount = 40; // Amount of damage dealt to the player

    // This function is called when something enters the enemy's collider marked as trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            PlayerStatus3 playerHealth = collision.GetComponent<PlayerStatus3>();
            playerHealth.TakeDamage(damageAmount);
            Debug.Log("Player Hit");
        }
    }
}
