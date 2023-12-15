using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMotion : MonoBehaviour
{
    private Animator anim;
  
    public void Start()
    {
        Playermotion player1 = FindObjectOfType<Playermotion>();
        PlayermotionLevel2 player2 = FindObjectOfType<PlayermotionLevel2>();
        PlayerStatus3 player3 = FindObjectOfType<PlayerStatus3>();
        PlayerStats4 player4 = FindObjectOfType<PlayerStats4>();

        if (player1 != null) {
            anim = Playermotion.anim;
        }
        else if (player2 != null) {
            anim = PlayermotionLevel2.animLevel2;
        }
        else if (player3 != null) {
            anim = PlayerStatus3.playerAnimation;
                }
        else if (player4 != null) {
            anim = PlayerStats4.playerAnimation;
        }

        
    }
    public void StopMovement()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (enemies != null)
        {
            foreach (GameObject enemy in enemies)
            {
                FreezeEnemiesMotion(enemy);
            }
        }
        if (players != null)
        {
            foreach (GameObject player in players)
            {
                FreezePlayerMotion(player);
            }
        }
    }

    public void ResumeMotion()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject enemy in enemies)
        {
            ResumeEnemiesMotion(enemy);
        }
        foreach (GameObject player in players)
        {
            ResumePlayerMotion(player);
        }
    }

    void FreezePlayerMotion(GameObject character)
    {
        Rigidbody2D body = character.GetComponent<Rigidbody2D>();

        Playermotion playerController1 = character.GetComponent<Playermotion>();

        PlayermotionLevel2 playerController2 = character.GetComponent<PlayermotionLevel2>();
     
        PlayerStatus3 playerController3 = character.GetComponent<PlayerStatus3>();
 
        PlayerStats4 playerController4 = character.GetComponent<PlayerStats4>();
        
        

        if (body != null)
        {
            body.constraints = RigidbodyConstraints2D.FreezeRotation;
            body.velocity = Vector2.zero;
  

        }

        if (playerController1 != null)
        {
            playerController1.enabled = false;
        }
        else if (playerController2 != null)
        {
            playerController2.enabled = false;
        }
        else if (playerController3 != null)
        {
            playerController3.enabled = false;
        }
        else if (playerController4 != null)
        {
            playerController4.enabled = false;
        }
        // Assuming "Idle" is the name of the idle animation
        if (playerController1 != null || playerController2 != null)
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Grounded", true);
        }
        else if(playerController3 != null || playerController4 != null)
        {
            anim.SetFloat("Speed", 0);
            anim.SetBool("OnGround", true);
        }
    }
    void FreezeEnemiesMotion(GameObject character)
    {
        Rigidbody2D body = character.GetComponent<Rigidbody2D>();
        EnemyFollow playerController = character.GetComponent<EnemyFollow>();

        if (body != null)
        {
            body.velocity = Vector2.zero;
            body.isKinematic = true;
        }

        if (playerController != null)
        {
            playerController.enabled = false;
        }
    }


    void ResumePlayerMotion(GameObject character)
    {
        Rigidbody2D body = character.GetComponent<Rigidbody2D>();

        Playermotion playerController1 = character.GetComponent<Playermotion>();

        PlayermotionLevel2 playerController2 = character.GetComponent<PlayermotionLevel2>();

        PlayerStatus3 playerController3 = character.GetComponent<PlayerStatus3>();

        PlayerStats4 playerController4 = character.GetComponent<PlayerStats4>();


        Animator anim = character.GetComponent<Animator>(); // Assuming you have an Animator component

        if (body != null)
        {
            body.isKinematic = false;
            body.velocity = Vector2.zero; // Reset velocity if necessary
            body.constraints = RigidbodyConstraints2D.None;
            body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        if (playerController1 != null)
        {
            playerController1.enabled = true;
        }
        else if (playerController2 != null)
        {
            playerController2.enabled = true;
        }
        else if (playerController3 != null)
        {
            playerController3.enabled = true;
        }
        else if (playerController4 != null)
        {
            playerController4.enabled = true;
        }

        if (anim != null)
        {
            if (playerController1 != null || playerController2 != null)
            {
                anim.SetBool("Walking", false);
            }
        }
       
    }
    void ResumeEnemiesMotion(GameObject character)
    {
        Rigidbody2D body = character.GetComponent<Rigidbody2D>();
        EnemyFollow enemyController = character.GetComponent<EnemyFollow>();

        if (body != null)
        {
            body.isKinematic = false;
            body.velocity = Vector2.zero; // Reset velocity if necessary
        }

        if (enemyController != null)
        {
            enemyController.enabled = true;
        }
    }


}
