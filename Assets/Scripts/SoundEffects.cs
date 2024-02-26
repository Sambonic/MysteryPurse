using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioClip damageSound; // Reference to the sound effect
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this object
        audioSource = GetComponent<AudioSource>();
        // Set the sound effect clip
        audioSource.clip = damageSound;
    }

    // Function to play the sound effect when the character is damaged
    public void PlayDamageSound()
    {
        // Check if the audio clip is not null and the AudioSource is not playing
        if (damageSound != null && !audioSource.isPlaying)
        {
            // Play the sound effect
            audioSource.PlayOneShot(damageSound);
        }
    }
}
