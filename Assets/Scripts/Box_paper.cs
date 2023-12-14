using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_paper2 : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BOX_Animation2.touched_The_Box2)
            gameObject.GetComponent<Renderer>().enabled = true;
    }
}
