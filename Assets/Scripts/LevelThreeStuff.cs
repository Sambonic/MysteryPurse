using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelThreeStuff : MonoBehaviour
{
    public int health = 100;
    public int lives = 3;
    private SpriteRenderer spriteRenderer;
    private int new_health;

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    //For the Letter
    [SerializeField] GameObject loveletter;
    private bool letterOpened = false;
    public InputField inputFieldOne;
    public InputField inputFieldTwo;
    public InputField inputFieldThree;
    private bool isFacingRight = true;
    public Rigidbody2D Fireblock;
    private Rigidbody2D rb;
    private int count = 0;
    private Vector3 respawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
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
    public void BigHeal()
    {
        this.health += 40;
        this.health = Mathf.Min(this.health, 100);
        FindObjectOfType<HealthBar>().ChangeHealthBarImage(this.health);
        Debug.Log("Added " + 40 + " Health. Current health is " + this.health.ToString());
    }
    public void SmallHeal()
    {
        this.health += 20;
        this.health = Mathf.Min(this.health, 100);
        FindObjectOfType<HealthBar>().ChangeHealthBarImage(this.health);
        Debug.Log("Added 20 Health. Current health is " + this.health.ToString());
    }
    public void TakeDamage(int damage)
    {
        if (this.isImmune == false)
        {
            this.health = this.health - damage;

            FindObjectOfType<SoundEffects>().PlayDamageSound();
            if (this.health < 0)
                this.health = 0;
            FindObjectOfType<HealthBar>().ChangeHealthBarImage(this.health);
            if (this.lives > 0 && this.health == 0)
            {
                LevelManager levelManager = FindObjectOfType<LevelManager>();
                HiddenSpikes hiddenSpikes = FindObjectOfType<HiddenSpikes>();
                WeaponFall weaponFall = FindObjectOfType<WeaponFall>();

                if (levelManager != null)
                {
                    if (levelManager != null)
                    {
                        levelManager.RespawnPlayer();
                        Debug.Log("Respawned");
                    }
                }
                if (hiddenSpikes != null)
                {
                    if (hiddenSpikes != null)
                    {
                        hiddenSpikes.Hide();
                    }
                }
                if (weaponFall != null)
                {
                    if (weaponFall != null)
                    {
                        weaponFall.Freeze();
                        weaponFall.PositionReset();
                    }
                }
                this.health = 100;
                FindObjectOfType<HealthBar>().ChangeHealthBarImage(this.health);
                this.lives--;
            }

            else if (this.lives == 0 && this.health == 0)
            {
                Debug.Log("Gameover");
                Destroy(this.gameObject);
                FindObjectOfType<NavigationController>().GoToMainMenuScene();
            }
            Debug.Log("Player Health:" + this.health.ToString());
            Debug.Log("Player Lives:" + this.lives.ToString());
        }
        PlayHitReaction();
    }

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
        if (collision.CompareTag("FireBlock"))
        {
            Fireblock.isKinematic = false;
        }
        if (collision.tag == "itemTag")
        {
            TakeDamage(20);
        }
        if (collision.tag == "Fire")
        {
            TakeDamage(30);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ladder" && Input.GetButton("Vertical"))
        {
            rb.velocity = new Vector2(transform.position.x, 3f);
        }

        if (collision.tag == "Chest" && Input.GetButton("Submit"))
        {

            letterOpened = true;
            loveletter.SetActive(true);
            Time.timeScale = 0f;
        }
        if (collision.tag == "Car" && Input.GetButton("Submit") && count == 0)
        {
            FindObjectOfType<PicturesManager>().SpawnRandomPicture(transform.position, transform.rotation);
            count++;
        }

    }
    public void closeLetter()
    {
        string one, two, three, four;
        one = inputFieldOne.text;
        two = inputFieldTwo.text;
        three = inputFieldThree.text;

        if (one == "elfayoum" && two == "pyramids" && three == "marasi")
        {
            letterOpened = false;
            loveletter.SetActive(false);
            Time.timeScale = 1f;
            FindObjectOfType<NavigationController>().GoToLevelFourScene();
        }
        else
        {
            letterOpened = false;
            loveletter.SetActive(false);
            Time.timeScale = 1f;
        }
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
}
