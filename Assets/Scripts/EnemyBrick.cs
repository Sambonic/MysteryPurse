using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Playermotion.attacking)
        {
            Destroy(gameObject, 0.4f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Fire")
        {
           
                Destroy(gameObject,2f);
            
           
        }
    }


}
