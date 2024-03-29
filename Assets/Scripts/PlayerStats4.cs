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

    public static Animator playerAnimation;

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

    //Flickering when damaged
    private SpriteRenderer spriteRenderer;

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        // scoreText.text = "Score: "+ points;
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
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
        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {

                this.isImmune = false;
                this.spriteRenderer.enabled = true;
                Debug.Log("Immunity has ended");
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
        if (collision.tag == "Big Health")
        {
            Destroy(collision.gameObject);
            BigHeal();
        }
        if (collision.tag == "Small Health")
        {
            Destroy(collision.gameObject);
            SmallHeal();
        }
        if (collision.tag == "Entrance")
        {

            if (background_music_manager.instance != null)
            {
                background_music_manager.instance.pause();
            }
            else
            {
                Debug.LogWarning("background_music_manager reference is null! Audio pause might not work.");
            }

            songCount++;
            if (songCount == 1)
            {
                audioSource.PlayOneShot(song);
            }

        }


        if (collision.tag == "Exit")
        {
            // audioSource.Stop();
            // musicManager.Play();
        }
        if (collision.tag == "rose")
        {
            FindObjectOfType<FadeToWhite>().StartFade();
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
        FindObjectOfType<SoundEffects>().PlayDamageSound();
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
            FindObjectOfType<pauseMenu>().RestartLevel();
        }
        Debug.Log("Player Health:" + this.health.ToString());
        Debug.Log("Player Lives:" + this.lives.ToString());
        PlayHitReaction();
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
    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0;
    }

    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if (this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }
}
