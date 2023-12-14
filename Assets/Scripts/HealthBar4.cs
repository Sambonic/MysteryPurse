using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar4 : MonoBehaviour
{
    private RectTransform bar;
    private Image barImage;


    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        setSize(Health4.totalHealth);
    }

    public void Damage(float damage)
    {
        if ((Health4.totalHealth -= damage) >= 0f)
        {
            Health4.totalHealth -= damage;
        }
        else
        {
            Health4.totalHealth = 0f;
        }

        //if players health go below 30% the health bar will be  red
        if (Health4.totalHealth < 0.3f)
        {
            barImage.color = Color.red;
        }
        setSize(Health4.totalHealth);
    }

    public void IncreaseHealth()
    {
        if (Health4.totalHealth > 0f && Health4.totalHealth < 0.8f)
        {
            Health4.totalHealth += 0.2f;
            setSize(Health4.totalHealth);
        }else if(Health4.totalHealth >= 0.8f && Health4.totalHealth < 1f)
        {
            Health4.totalHealth = 1f;
            setSize(Health4.totalHealth);
        }
        if (Health4.totalHealth > 0.3f)
        {
            barImage.color = Color.green;
        }
    }

    public void IncreaseHealth(float amount)
    {
        if (Health4.totalHealth > 0f && Health4.totalHealth < 0.8f)
        {
            Health4.totalHealth += amount;
            Debug.Log("Health increased");
            setSize(Health4.totalHealth);
        }
        else if (Health4.totalHealth >= 0.8f && Health4.totalHealth < 1f)
        {
            Health4.totalHealth = 1f;
            setSize(Health4.totalHealth);
        }
        if (Health4.totalHealth > 0.3f)
        {
            barImage.color = Color.green;
        }
    }

    public void resetHealth()
    {
        Health4.totalHealth = 1f;
        setSize(Health4.totalHealth);
        barImage.color = Color.green;
    }

    //update the health bar
    public void setSize(float size)
    {
        bar.localScale = new Vector3(size, 1f);
    }

}
