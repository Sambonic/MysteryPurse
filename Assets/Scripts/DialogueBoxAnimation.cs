using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxAnimationLevel2 : MonoBehaviour
{
    public Sprite[] images;
    private Image spriteRenderer;
    private int currentImageIndex = 0;
    public float delayBetweenImages = 0.5f; // Set the delay time in seconds

    void Start()
    {
        spriteRenderer = GetComponent<Image>();

        if (images.Length > 0 && spriteRenderer != null)
        {
            StartCoroutine(ChangeImageWithDelay());
        }
        else
        {
            Debug.LogError("Images array is empty or Image component is not assigned!");
        }
    }

    IEnumerator ChangeImageWithDelay()
    {
        while (true)
        {
            ChangeToNextImage();
            yield return new WaitForSeconds(delayBetweenImages);
        }
    }

    public void ChangeToNextImage()
    {
        currentImageIndex = (currentImageIndex + 1) % images.Length;
        spriteRenderer.sprite = images[currentImageIndex];
    }
}
