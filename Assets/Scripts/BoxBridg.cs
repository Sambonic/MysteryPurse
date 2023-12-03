using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxBridg : MonoBehaviour
{
    public bool rotate;
    public bool rotate2;
  
    void Update()
    {
        rotate = BOX_Animation.touched_The_Box;
        rotate2 = BOX_Animation2.touched_The_Box2;
        if (rotate)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        if(rotate2)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        }
    }
}
