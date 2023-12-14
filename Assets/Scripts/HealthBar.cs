using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBar : MonoBehaviour
{
    public Sprite[] healthBarImages;
    public Image[] hearts;
    public Image healthBarImage;
    public TextMeshProUGUI healthValue;
    int index = 0;
    int heartsRemaining = 2;
    public void ChangeHealthBarImage(int health)
    {
        
        if(health >= 90)
        {
            index = 0;
        }
        else if (health >= 70)
        {
            index = 1;
        }
        else if(health >= 50)
        {
            index = 2;
        }
        else if (health >= 30)
        {
            index = 3;
        }
        else if (health >= 10)
        {
            index = 4;
        }
        else if (health <= 0)
        {
            index = 5;
        }

        if (index >= 0 && index < healthBarImages.Length)
        {
            healthBarImage.sprite = healthBarImages[index];
        }
        else
        {
            Debug.LogError("Invalid sprite index");
        }
        healthValue.text = health.ToString();

        if (health >= 50)
        {
            healthValue.color = Color.black;
        }
        else
        {
            healthValue.color = Color.white;
        }
        if (health <= 0)
        {
            Destroy(hearts[heartsRemaining--]);
            Debug.Log("Heart removed");
        }
    }
}
