using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot3 : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;//reference for the bullet object
    public float fireRate = 1.0f;
    private float nextFireTime = 0f;
    private PlayerStatus3 player;
    private bool shooting = false;
    public float chaseDistance = 5f;

    void Start()
    {
        player = FindObjectOfType<PlayerStatus3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= chaseDistance)
            {
                shooting = true;
            }
            if (Time.time >= nextFireTime && shooting)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);//respawn the object bullet, at its position, with its rotation

    }
}
