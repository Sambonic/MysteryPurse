using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaldBossMessage : MonoBehaviour
{

    public GameObject FinalBossMessageText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(FinalBossMessageText);
            Destroy(gameObject);
        }
    }
}
