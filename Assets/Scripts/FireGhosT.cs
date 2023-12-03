using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireGhosT : MonoBehaviour
{
    [SerializeField] public static bool Fire_Ghost_is_firing;
    private void Awake()
    {
       Fire_Ghost_is_firing = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Playermotion.attacking)
            Fire_Ghost_is_firing = true;
    }
}
