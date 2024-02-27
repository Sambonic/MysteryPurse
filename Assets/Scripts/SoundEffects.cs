using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] public AudioClip[] soundEffects; // Array of sound effects (now marked with SerializeField)
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Check if the sound effects array is not null and contains at least one clip
        if (soundEffects == null || soundEffects.Length == 0)
        {
            Debug.LogError("No sound effects assigned in the inspector!");
            return; // Exit if no valid sounds are provided
        }
    }

    // Function to play a random sound effect
    public void PlayDamageSound()
    {
        // Choose a random index within the valid range of the array
        int randomIndex = Random.Range(0, soundEffects.Length);

        // Check if the randomly chosen sound clip is not null
        if (soundEffects[randomIndex] != null)
        {
            // Calculate the starting time skipping the first 0.2 seconds
            float normalizedStartTime = 0.5f / soundEffects[randomIndex].length;

            audioSource.clip = soundEffects[randomIndex];
            audioSource.time = normalizedStartTime;
            audioSource.PlayOneShot(soundEffects[randomIndex]);
        }
        else
        {
            Debug.LogError("An element in the sound effects array is null!");
        }
    }
}
