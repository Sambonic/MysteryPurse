using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingPictures : MonoBehaviour
{
    public GameObject MissingPicture;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(MissingPicture);
        }
    }
}
