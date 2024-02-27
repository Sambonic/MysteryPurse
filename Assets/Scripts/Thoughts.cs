using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField] private string[] sentences; // Array of sentences to display
    [SerializeField] private float triggerDistance;  // Distance to trigger the bubble
    [SerializeField] private GameObject speechBubblePrefab; // Prefab for the speech bubble
    [SerializeField] private float displayTime; // Time the bubble stays visible

    private GameObject speechBubbleInstance;
    private float timer;

    private void Awake()
    {
        speechBubbleInstance = Instantiate(speechBubblePrefab, transform.position + Vector3.up, Quaternion.identity);
        speechBubbleInstance.transform.parent = transform; // Set NPC as parent
        speechBubbleInstance.SetActive(false); // Hide initially
    }

    private void Update()
    {
        // Check if player is close enough
        // Show bubble and choose random sentence
        speechBubbleInstance.SetActive(true);
        //speechBubbleInstance.GetComponentInChildren<TextMeshProUGUI>().text = sentences[Random.Range(0, sentences.Length)];
        timer = displayTime;
    

        // Hide bubble after display time
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                speechBubbleInstance.SetActive(false);
            }
        }
    }
}