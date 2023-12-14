using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
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

    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (this.isImmune == true) {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {

                this.isImmune = false;
                this.spriteRenderer.enabled = true;
                Debug. Log("Immunity has ended");
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
        Debug.Log("Added "+ 40 +" Health. Current health is " + this.health.ToString());
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
                    levelManager.RespawnPlayer();
                }

                if (hiddenSpikes != null)
                {
                    hiddenSpikes.Hide();
                }

                if (weaponFall != null)
                {
                    weaponFall.Freeze();
                    weaponFall.PositionReset();
                }
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
        PlayHitReaction();
    }
}
