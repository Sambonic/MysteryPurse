using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : EnemyController
{
    public float chaseDistance = 5f;

    private PlayerStatus3 player;
    private bool isChasing = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStatus3>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer<= chaseDistance)
        {
            isChasing = true;
        }
        if (isChasing)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 3f * Time.deltaTime);
        }
        
    }
  /*  void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            player.health = player.health - 20;
        }
    }*/
}
