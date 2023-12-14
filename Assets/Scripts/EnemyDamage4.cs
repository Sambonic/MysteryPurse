using UnityEngine;

public class EnemyDamage4 : MonoBehaviour
{
    public float damageAmount = 0.4f; // Amount of damage dealt to the player

    // This function is called when something enters the enemy's collider marked as trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            PlayerStats4 playerHealth = collision.GetComponent<PlayerStats4>();
            playerHealth.damage(damageAmount);
            Debug.Log("Player Hit");
        }
    }
}
