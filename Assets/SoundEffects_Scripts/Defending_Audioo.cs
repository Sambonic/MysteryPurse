using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defending_Audioo : MonoBehaviour
{
    public AudioClip[] audioSources;

    public AudioSource randomSound;

    void Start()
    {
        randomSound = GetComponent<AudioSource>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {

            randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
            randomSound.Play();
        }
    }
}
