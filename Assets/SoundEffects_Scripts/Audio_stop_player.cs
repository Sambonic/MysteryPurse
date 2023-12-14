using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_stop_player : MonoBehaviour
{
    public float timer = 0.0f;
    [SerializeField] float total_time;
    public bool collisionN = false;
    public bool Sound_played = false;
    public AudioClip[] audioSources;
    public AudioSource randomSound;
    [SerializeField] public static bool stop_the_player = false;
    public static string clip_name;
    public static int Random_index;

    void Start()
    {
        randomSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collisionN = true;
            if (!Sound_played)
            {
                Random_index = Random.Range(0, audioSources.Length);
                randomSound.clip = audioSources[Random_index];
                clip_name = randomSound.clip.ToString();
                print(clip_name);
                randomSound.Play();
                Sound_played = true;
            }
           
        }

    }
    private void Update()
    {

        //var horizontalAxis = Input.GetAxis("Horizontal");
        //var verticalAxis = Input.GetAxis("Vertical");

        if (collisionN)
        {

            timer += Time.deltaTime;

            if (timer < total_time)
            {
                stop_the_player = true;
            }
            else
            {
                stop_the_player = false;
            }
          
        }
    }

}
