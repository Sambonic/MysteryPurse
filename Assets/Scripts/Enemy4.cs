using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    public bool isFacingRight = false;
    public float maxSpeed = 3f;
    public int damage = 6;
    public float chaseDistance = 5f;

    private PlayerStats4 player;
    private bool isChasing = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats4>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= chaseDistance)
            {
                isChasing = true;
            }
            if (isChasing)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 3f * Time.deltaTime);
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.TakeDamage(damage);
        }
    }
}
