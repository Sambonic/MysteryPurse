using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Audio_with_puase1 : MonoBehaviour
{
    public float timer = 0.0f;
    public AudioSource Sound;
    [SerializeField] float total_time;
    public bool collisionN = false;
    public bool Sound_played = false;
    public static bool show_paper = false;
    public static bool stop_the_player = false;
    public static bool touched_The_Box = false;

    void Start()
    {
        Sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
           
              collisionN = true;
              touched_The_Box = true;

            if (!Sound_played)
            { 
                Sound.Play();
                Sound_played = true;
            }


        }
    }
    private void Update()
    {
        if (collisionN)
        {

            timer += Time.deltaTime;

            if (timer < total_time)
            {
                stop_the_player = true;
                show_paper = true;
            }
            else
            {
                stop_the_player = false;
                show_paper = false;

            }
        }
    }

}