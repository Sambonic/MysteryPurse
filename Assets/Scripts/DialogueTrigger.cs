using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject uiObject;
    public bool HadDialogue = false;
    // Start is called before the first frame update
    void Start()
    {
        TriggerDeactivate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!HadDialogue)
        {
            if (collision.tag == "Player")
            {
                uiObject.SetActive(true);
            }
        }
    }

    public void TriggerDeactivate()
    {
        uiObject.SetActive(false);
    }

    public void DialogueDone()
    {
        // Destroy the GameObject to which this script is attached
        Destroy(gameObject);
    }
}
