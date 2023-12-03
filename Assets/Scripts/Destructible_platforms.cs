using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_platforms : MonoBehaviour
{
    int hit_counter = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Playermotion.attacking)
        {
            hit_counter++;
            if (hit_counter == 3) 
            {
                Destroy(gameObject);
            }
        }
    }

}
