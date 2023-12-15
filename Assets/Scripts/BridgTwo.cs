using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgTwo : MonoBehaviour
{
    public bool rotate;

    void Update()
    {
        rotate = BOX_Animation2.touched_The_Box2;
        if (rotate)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
       
    }
}
