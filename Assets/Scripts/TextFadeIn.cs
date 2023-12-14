using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextFadeIn : MonoBehaviour
{
    public float fadeInTime = 2.0f;
    public TextMeshProUGUI textComponent;
    private float elapsedTime = 0f;
    bool fadedIn = false;


    void Start()
    {
        textComponent.alpha = 0;
    }

    void Update()
    {
        if (elapsedTime < fadeInTime && !fadedIn)
        {
            textComponent.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
            elapsedTime += Time.deltaTime;
        }
        else if (fadedIn)
        {

            textComponent.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeInTime);
            elapsedTime += Time.deltaTime;
        }
        else
        {
            Invoke("DestroyMessage", 2f);
        }
    }

    void DestroyMessage()
    {
        Destroy(gameObject);
    }
}
