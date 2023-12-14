using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping_Audio : MonoBehaviour
{
    public AudioClip[] audioSources;
    public AudioSource randomSound;

    void Start()
    {
        randomSound = GetComponent<AudioSource>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
            randomSound.Play();
        }
    }
}
