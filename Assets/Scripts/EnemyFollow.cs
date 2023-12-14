using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyController
{
    public PlayermotionLevel2 player;
    // Start is called before the first frame update
    void Start()
    {
        PlayermotionLevel2 level2player = FindObjectOfType<PlayermotionLevel2>();
        if (level2player != null)
        {
            player = FindObjectOfType<PlayermotionLevel2>();
        }
        else
        {
            Debug.Log("Player is dead. Game Over");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxSpeed * Time.deltaTime);
        }
    }
}
