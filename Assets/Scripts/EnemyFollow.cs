using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : EnemyController
{
    public PlayermotionLevel2 player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayermotionLevel2>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxSpeed * Time.deltaTime);
    }
}
