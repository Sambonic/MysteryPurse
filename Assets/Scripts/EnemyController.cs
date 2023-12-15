using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 30;

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerStatus3 player3 = FindObjectOfType<PlayerStatus3>();
            PlayerStats player2 = FindObjectOfType<PlayerStats>();
            if (player3 != null)
            {
                player3.TakeDamage(damage);
                Debug.Log("Player 3 took damage");
            }
            else if( player2 != null)
            {
                player2.TakeDamage(damage);
            }

        }
    }
}
