using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar3 : MonoBehaviour
{
    private RectTransform bar;
    private Image barImage;


    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        setSize(Health3.totalHealth);
    }

    public void Damage(float damage)
    {
        if ((Health3.totalHealth -= damage) >= 0f)
        {
            Health3.totalHealth -= damage;
        }
        else
        {
            Health3.totalHealth = 0f;
        }

        //if players health go below 30% the health bar will be  red
        if (Health3.totalHealth < 0.3f)
        {
            barImage.color = Color.red;
        }
        setSize(Health3.totalHealth);
    }

    public void IncreaseHealth()
    {
        if (Health3.totalHealth > 0f && Health3.totalHealth < 0.8f)
        {
            Health3.totalHealth += 0.2f;
            setSize(Health3.totalHealth);
        }else if(Health3.totalHealth >= 0.8f && Health3.totalHealth < 1f)
        {
            Health3.totalHealth = 1f;
            setSize(Health3.totalHealth);
        }
        if (Health3.totalHealth > 0.3f)
        {
            barImage.color = Color.green;
        }
    }

    public void IncreaseHealth(float amount)
    {
        if (Health3.totalHealth > 0f && Health3.totalHealth < 0.8f)
        {
            Health3.totalHealth += amount;
            Debug.Log("Health increased");
            setSize(Health3.totalHealth);
        }
        else if (Health3.totalHealth >= 0.8f && Health3.totalHealth < 1f)
        {
            Health3.totalHealth = 1f;
            setSize(Health3.totalHealth);
        }
        if (Health3.totalHealth > 0.3f)
        {
            barImage.color = Color.green;
        }
    }

    public void resetHealth()
    {
        Health3.totalHealth = 1f;
        setSize(Health3.totalHealth);
        barImage.color = Color.green;
    }

    //update the health bar
    public void setSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }

}
