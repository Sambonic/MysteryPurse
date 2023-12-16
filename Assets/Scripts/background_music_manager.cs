    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_music_manager : MonoBehaviour
{
    private AudioSource audioSource;
    public static background_music_manager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Ensure this GameObject persists across scenes
        DontDestroyOnLoad(gameObject);

        // Play the background music if not already playing
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    public void pause()
    {
        audioSource.Pause();
    }

}
