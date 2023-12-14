using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Source;
    Collider2D SoundTrigger;

    void Start()
    {
        Source = GetComponent<AudioSource>();
        SoundTrigger = GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        Source.Play();
    }
}
