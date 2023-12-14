using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneAcquired : MonoBehaviour
{
    public GameObject DialogueTriggerL2CS2;
    public GameObject BoneAcquiredMessage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            GameObject dogObject = GameObject.FindGameObjectWithTag("Dog");

            if (dogObject != null)
            {
                Instantiate(DialogueTriggerL2CS2, dogObject.transform.position, Quaternion.identity);
                Instantiate(BoneAcquiredMessage);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("Dog object not found!");
            }
        }
    }
}
