using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
            if (Audio_with_puase.show_paper==true)
            gameObject.GetComponent<Renderer>().enabled = true;
            else
            gameObject.GetComponent<Renderer>().enabled = false;

    }
}
