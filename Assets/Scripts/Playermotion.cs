using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Playermotion : MonoBehaviour
{
    
    /*[SerializeField]*/
    float spead;
    // SerializeField means that i can change this value from unity editor.
    private float horizontalInput;
    float verticalInput;
    private Rigidbody2D body;//So this body that i want to make it move is an Rigid body 2D.
    // Rigidbody class inherites from componant class.
    public static Animator anim;
    public bool grounded = false;
    public bool is_protected = false;
    public static bool attacking = false;


    Vector3 res_point;
    private void Awake() //Awake method will be called each time the script is loaded.
    {                   //                     (at the beginning of the game).
        body = GetComponent<Rigidbody2D>();
        //So we have body that has rigidbody properties and we want to get those componentes.

        anim = GetComponent<Animator>();
        res_point = transform.position; // the point that main charcter starts from.

    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Finish"&& is_protected==false&&!attacking)
    //    {
    //        //Destroy(gameObject);
    //        transform.position = res_point;
    //    }

    //    else if(collision.tag == "Finish" && is_protected == false &&attacking)
    //    {

    //    }
    //}


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
            body.velocity = new Vector2(body.velocity.x, 11);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;

    }

    public void check_puzzle_answer()
    {
        if(Puzzle_check.Wrong_Answer)
        {
            FindObjectOfType<PlayerStats>().TakeDamage(100);
            //rset back
            Puzzle_check.Wrong_Answer = false;
        }
    }
    public void Shielding()
    {
        is_protected = false;
        anim.SetBool("Shielding", is_protected);
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Shielding", true);
            is_protected = true;
        }
    }

    void Attack()
    {
        attacking = false;
        anim.SetBool("Attack", attacking);
        if (Input.GetKey(KeyCode.F))
        {
            attacking = true;
            anim.SetBool("Attack", attacking);
            // anim.SetTarget("attack");
        }
    }

    private void Update() //Update function is called(checked) at each frame in the game.
    // So, need update here it's going to make sure that on every frame of our game inputsare being recorded and the player
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //We can call GetAxis function only in update method.
        // mascara = GameObject.FindGameObjectWithTag("Finish");
        //Debug.Log(mascara.transform);

       

        Move();

        Jump();

        Rotate();

        FixedSlope();

        Shielding();

        Attack();

        anim.SetBool("Grounded", grounded);

        check_puzzle_answer();


        if (Audio_stop_player.stop_the_player || Audio_with_puase.stop_the_player || Audio_with_puase1.stop_the_player)
        {
            body.velocity = new Vector2(0,0);
            transform.localScale = new Vector3(-1, 1, 1);
            anim.enabled = false;
            print("Now the player cannot move");
        }
        else
        {
            anim.enabled = true ;

        }
    }

}





