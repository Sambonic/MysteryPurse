using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResPointsMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private bool right = true;
    [SerializeField] private bool left;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "right")
        {
            right = true;
        }
        else if (collision.gameObject.tag == "left")
        {
            left = true;
        }
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if (right)
        {
            body.velocity = new Vector2(-5, 0);
            right = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (left)
        {
            body.velocity = new Vector2(5, 0);
            left = false;
            transform.localScale = Vector3.one;
        }
    }

}
