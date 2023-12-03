using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_chase : MonoBehaviour
{
    
    public GameObject player;
    public float spead;
    private float distance;
    public void chasing()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position,
        spead * Time.deltaTime);
    }
    void Update()
    {
        chasing();
    }
}
