using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeFromWhite : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime = 4.0f; // adjust fade duration

    void Start()
    {
        // Set initial alpha to fully opaque (white)
        fadeImage.color = new Color(1f, 1f, 1f, 1f);

        // Start coroutine to fade over time
        StartCoroutine(FadeImageCoroutine());
    }

    IEnumerator FadeImageCoroutine()
    {
        float timeElapsed = 0f;

        while (timeElapsed < fadeTime)
        {
            // Calculate current alpha based on time progression
            float alpha = 1f - (timeElapsed / fadeTime);

            // Update image color with adjusted alpha
            fadeImage.color = new Color(1f, 1f, 1f, alpha);

            // Wait for next frame before updating again
            yield return new WaitForEndOfFrame();

            timeElapsed += Time.deltaTime;
        }

        // Set final alpha to fully transparent
        fadeImage.color = new Color(1f, 1f, 1f, 0f);
        yield return new WaitForSeconds(3.0f);
        FindObjectOfType<NavigationController>().GoToMainMenuScene();
        // Optional: After fade is complete, you can disable the image
        // fadeImage.gameObject.SetActive(false); 
    }
}

