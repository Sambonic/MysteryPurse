using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX_Animation2 : MonoBehaviour
{
    public Animator anim;
    public static bool touched_The_Box2;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("TouchBoX", false);
        touched_The_Box2 = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touched_The_Box2 = true;
        }
    }

    public void Update()
    {
        if (touched_The_Box2)
            anim.SetBool("TouchBoX", true);
    }

}
