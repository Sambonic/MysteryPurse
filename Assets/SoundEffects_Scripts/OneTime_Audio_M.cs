using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTime_Audio_M : MonoBehaviour
{
    public AudioSource Source;
    Collider2D SoundTrigger;
    public bool played;

    void Start()
    {
        Source = GetComponent<AudioSource>();
        SoundTrigger = GetComponent<Collider2D>();
        played = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (played&&collision.tag=="Player")
        {
            Source.Play();
            played = false;
        }

    }
}
