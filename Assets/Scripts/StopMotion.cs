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

        if (player1 != null){
            //this.anim = Playermotion.anim;
        }
        else if (player2 != null) {
            anim = PlayermotionLevel2.animLevel2;
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
        PlayermotionLevel2 playerController = character.GetComponent<PlayermotionLevel2>();

        if (body != null)
        {
            body.constraints = RigidbodyConstraints2D.FreezeRotation;
            body.velocity = Vector2.zero;
  

        }

        if (playerController != null)
        {
            playerController.enabled = false;
        }

        // Assuming "Idle" is the name of the idle animation
        anim.SetBool("Walking", false);
        anim.SetBool("Grounded", true);
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
        PlayermotionLevel2 playerController = character.GetComponent<PlayermotionLevel2>();
        Animator anim = character.GetComponent<Animator>(); // Assuming you have an Animator component

        if (body != null)
        {
            body.isKinematic = false;
            body.velocity = Vector2.zero; // Reset velocity if necessary
            body.constraints = RigidbodyConstraints2D.None;
        }

        if (playerController != null)
        {
            playerController.enabled = true;
        }

        if (anim != null)
        {
            // Assuming you have an "Idle" animation
            anim.SetBool("Walking", false);
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
