using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class PlayermotionLevel2 : MonoBehaviour
{
    /*[SerializeField]*/ float spead;
    // SerializeField means that i can change this value from unity editor.
    private float horizontalInput;
    float verticalInput;
    private Rigidbody2D body;//So this body that i want to make it move is an Rigid body 2D.
    // Rigidbody class inherites from componant class.
    private Animator anim;
    private bool grounded=false;
    Vector3 res_point;

    private bool hasWeapon = false;

    //Ladder logic
    public float climbSpeed = 5f;
    public float ladderDetectionRange = 1.5f;



    private void Awake() //Awake method will be called each time the script is loaded.
    {                   //                     (at the beginning of the game).
        body = GetComponent<Rigidbody2D>();
        //So we have body that has rigidbody properties and we want to get those componentes.

        anim = GetComponent<Animator>();
        res_point = transform.position; // the point that main charcter starts from.
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Shield")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Pin Sword")
        {
            Destroy(collision.gameObject);
            hasWeapon = true;
        }
        else if (collision.tag == "Big Health")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<PlayerStats>().BigHeal();
        }
        else if (collision.tag == "Small Health")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<PlayerStats>().SmallHeal();
        }
        else if (collision.tag == "FallingBridge")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Ladder" && Input.GetKeyDown(KeyCode.W))
        {
            body.velocity = new Vector2(transform.position.x, 3f);
        }
    }

    private void Move()
    {
        // x and y.
        // So velocity is a function in Rigidbody2D class
        // It means that the input will affect only the velocity of x axis
        // and y axis's velocity will no be affected anymore.
        if (Input.GetKey(KeyCode.R))
        {
            body.velocity = new Vector2(horizontalInput * 10, body.velocity.y);
            anim.SetBool("Run", horizontalInput != 0);
            anim.SetBool("Walking", false);
        }
        else
        {
            body.velocity = new Vector2(horizontalInput * 5, body.velocity.y);
            anim.SetBool("Walking", horizontalInput != 0);
            anim.SetBool("Run", false);


        }

    }
    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            body.velocity = new Vector2(body.velocity.x, 6);
            grounded = false;
        }
    }
    private void Rotate()
    {
        if (horizontalInput > 0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput < -0.1f)
        {
            transform.localScale = Vector3.one; //.one means,set all(x,y,z) by value 1.
        }
    }    
    private void FixedSlope()
    {
        var rot = gameObject.transform.localRotation.eulerAngles; //get the angles
        rot.Set(0f, 0f, -1f); //set the angles
        gameObject.transform.localRotation = Quaternion.Euler(rot); //update the transform
    }
    private void Attack()
    {
        if (hasWeapon && Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    private void Update() //Update function is called(checked) at each frame in the game.
    // So, need update here it's going to make sure that on every frame of our game inputsare being recorded and the player
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //We can call GetAxis function only in update method.
         verticalInput = Input.GetAxis("Vertical");


        if (Mathf.Abs(body.velocity.y) < 0.07f)
        {
            grounded = true;
        }



        Move();

        Jump();
        
        Rotate();

        FixedSlope();

        Attack();

        anim.SetBool("Grounded", grounded);
    }


}





