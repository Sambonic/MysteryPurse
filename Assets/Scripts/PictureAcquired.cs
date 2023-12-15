using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PictureAcquired : MonoBehaviour
{
    public float fadeInTime = 2.0f;
    public TextMeshProUGUI textComponent;
    private float elapsedTime = 0f;
    void Start()
    {
        textComponent.alpha = 0;
    }

    void Update()
    {
        if (elapsedTime < fadeInTime)
        {
            textComponent.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            textComponent.alpha = 1f;
            Invoke("DestroyMessage", 2f);
        }
    }
    public void PicturesGathered(float pictures)
    {
        if (pictures != 3)
        {
            textComponent.text = "Gathered " + pictures.ToString() + "/3 places";
        }
        else
        {
            textComponent.text = "All pictures gathered. Go up to the red flag to proceed.";
        }
    }

    void DestroyMessage()
    {
        Destroy(gameObject);
    }
}
