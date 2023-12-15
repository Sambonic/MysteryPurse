using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public Transform target;
    void FixedUpdate()
    {

        if (target != null)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);
        }
        
    }
}
