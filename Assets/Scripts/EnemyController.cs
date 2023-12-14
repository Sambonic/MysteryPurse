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
            FindObjectOfType<PlayerStatus3>().takeDamage(damage);
        }
    }
}
