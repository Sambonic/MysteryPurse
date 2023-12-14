using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_paper : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BOX_Animation.touched_The_Box)
            gameObject.GetComponent<Renderer>().enabled = true;
    }
}
