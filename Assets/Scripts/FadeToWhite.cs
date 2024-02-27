using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToWhite : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 6.0f; // adjust speed for desired fade duration
    [SerializeField] private Canvas canvasToDisable;
    private bool isFading = false;

    void Start()
    {
        fadeImage.color = new Color(1, 1, 1, 0); // start with transparent white
    }

    void Update()
    {
        if (isFading)
        {
            FadeIn();
        }
    }

    public void StartFade()
    {
        isFading = true;
        canvasToDisable.enabled = false;
    }

    void FadeIn()
    {
        float alpha = fadeImage.color.a;
        alpha += fadeSpeed * Time.deltaTime;

        if (alpha >= 1.0f)
        {
            alpha = 1.0f;
            isFading = false;
      
            FindObjectOfType<NavigationController>().GoToConclusion();
        }

        fadeImage.color = new Color(1, 1, 1, alpha);
    }
}

