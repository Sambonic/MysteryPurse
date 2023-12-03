using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FireGhosT.Fire_Ghost_is_firing)
            gameObject.GetComponent<Renderer>().enabled = true;
    }
}
