using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_check : MonoBehaviour
{
    public static bool Wrong_Answer= false;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CanNotForgetDateBox" && Audio_stop_player.Random_index==2) 
        {
            print("Level one passed");
        }
        else if (collision.tag == "TheBest_daYBox" && Audio_stop_player.Random_index == 0)
        {
            print("Level one passed");
        }
        else if (collision.tag == "TheworstDayBox" && Audio_stop_player.Random_index == 1)
        {
            print("Level one passed");

        }
        else
        {
            print("Wrong Puzzle answar");
            Wrong_Answer = true;
            print(collision.tag.ToString());
        }
        
    }
}
