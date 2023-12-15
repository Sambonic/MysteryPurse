using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueText : MonoBehaviour
{
    public string[] sentences;

    public TextMeshProUGUI textMeshProComponent;
    public Button nextButton;
    private int currentSentenceIndex = 0;
    public float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;
    void Start()
    {
        FindObjectOfType<StopMotion>().StopMovement();
        nextButton.onClick.AddListener(OnNextButtonClick);
        OnNextButtonClick();
    }

    void OnNextButtonClick()
    {

        if (currentSentenceIndex < sentences.Length)
        {
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            typingCoroutine = StartCoroutine(TypeSentence(sentences[currentSentenceIndex]));
            currentSentenceIndex++;
        }
        else
        {
            Debug.Log("End of dialogue");
            FindObjectOfType<StopMotion>().ResumeMotion();
            FindObjectOfType<DialogueTrigger>().TriggerDeactivate();
            FindObjectOfType<DialogueTrigger>().DialogueDone();
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        textMeshProComponent.text = ""; // Clear the text before typing

        foreach (char letter in sentence.ToCharArray())
        {
            textMeshProComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
