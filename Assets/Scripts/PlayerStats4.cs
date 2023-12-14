using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats4 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    public float Direction = 0f;
    private Rigidbody2D rb;

    public Transform groundCheck; //Empty object attached to the player's feet
    public float groundCheckRadius; //float to check if there is overlaping in end of the character's end feet
    public LayerMask groundLayer; //use layers to specify what is ground
    private bool isTouchingGround;

    private Animator playerAnimation;

    private Vector3 respawnPoint;// respawn of the player
    public GameObject fallDetector; //to make it follow with the player

    private bool isFacingRight = true; // Flag to track the character's facing direction

    public int points = 0;
    //public HealthBar3 healthbar;
    public int health = 100;
    public int lives = 3;

    private AudioSource audioSource;
    public AudioClip song;
    private int songCount = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        // scoreText.text = "Score: "+ points;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Direction = Input.GetAxis("Horizontal");
        if (Direction > 0f)
        {
            rb.velocity = new Vector2(Direction * moveSpeed, rb.velocity.y);
            if (!isFacingRight)
            {
                Flip();
            }
        }
        else if (Direction < 0f)
        {
            rb.velocity = new Vector2(Direction * moveSpeed, rb.velocity.y);
            if (isFacingRight)
            {
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        playerAnimation.SetFloat("Speed", Mathf.Abs(rb.velocity.x));//finding the velocity of the player in x axis, we are using Math.Abs because when it moves left it will be negative so the walking condition will not be fulfilled
        playerAnimation.SetBool("OnGround", isTouchingGround);

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y); //fall detector position will be changed by the players x axis only
        if (this.health <= 0 && lives > 0)
        {
            // Destroy(this.gameObject);
            transform.position = respawnPoint;
            this.health = 100;
            FindObjectOfType<HealthBar>().ChangeHealthBarImage(this.health);
            this.lives--;
        }
        else if (health <= 0.0f && lives <= 0)
        {
            Destroy(this.gameObject);
        }

        if (points >= 27)
        {
            GameObject[] destroyBoxes = GameObject.FindGameObjectsWithTag("destroyBox");

            foreach (GameObject box in destroyBoxes)
            {
                Destroy(box);
            }
        }


    }

    //method detects collision when 1 object enters another object's collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fallDetector")
        {
            TakeDamage(100);
            transform.position = respawnPoint; // respawn the player to the beginning
        }
        if (collision.tag == "checkpoint")
        {
            respawnPoint = transform.position; //update the respawn point to the player's new position (new checkpoint)
        }

        if (collision.tag == "itemTag")
        {
            TakeDamage(20);
        }
        if (collision.tag == "Entrance")
        {
            songCount++;
            if (songCount == 1)
            {
                audioSource.PlayOneShot(song);
            }
        }

        if(collision.tag == "Exit")
        {
            audioSource.Stop();
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder" && Input.GetButton("Vertical"))
        {
            rb.velocity = new Vector2(transform.position.x, 3f);
        }

        if (collision.tag == "Fire")
        {
            TakeDamage(30);
        }


    }

    public void BigHeal()
    {
        health += 40;
        health = Mathf.Min(health, 100);
        FindObjectOfType<HealthBar>().ChangeHealthBarImage(health);
        Debug.Log("Added " + 40 + " Health. Current health is " + health.ToString());
    }

    public void SmallHeal()
    {
        health += 20;
        health = Mathf.Min(health, 100);
        FindObjectOfType<HealthBar>().ChangeHealthBarImage(health);
        Debug.Log("Added 20 Health. Current health is " + health.ToString());
    }

    public void TakeDamage(int damage)
    {
        this.health = this.health - damage;

        if (this.health < 0)
            this.health = 0;
        FindObjectOfType<HealthBar>().ChangeHealthBarImage(this.health);
        if (this.lives > 0 && this.health == 0)
        {
            transform.position = respawnPoint;
            this.health = 100;
            FindObjectOfType<HealthBar>().ChangeHealthBarImage(this.health);
            this.lives--;
        }

        else if (this.lives == 0 && this.health == 0)
        {
            Debug.Log("Gameover");
            Destroy(this.gameObject);
            //FindObjectOfType<NavigationController>().GoToGameOverScene();
        }
        Debug.Log("Player Health:" + this.health.ToString());
        Debug.Log("Player Lives:" + this.lives.ToString());

    }



    void Flip()
    {
        isFacingRight = !isFacingRight; // Toggle the facing direction flag

        //  Vector3 flippedScale = transform.localScale;
        //  flippedScale.x *= -1; // Flip the scale in the x-axis

        transform.Rotate(0f, 180f, 0f);
    }

    void die()
    {
        Destroy(this.gameObject);
    }
    public void addPoints(int p)
    {
        points += p;
        //  scoreText.text = "Score: " + points;
        Debug.Log("Points added");
    }
}
