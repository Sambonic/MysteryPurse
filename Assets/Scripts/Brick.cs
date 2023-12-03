using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private SpriteRenderer sr;                                             // Brick
public Sprite explodedBlock;
    public int counter;
    public bool touched;
    public float time;
void Start()
{
    sr = GetComponent<SpriteRenderer>();
        counter = 0;
        touched = false;
        time = 0;

}
    void ExplodeBrick()
    {
        sr.sprite = explodedBlock;
        Destroy(gameObject, 0.2f);
    }

    void Update()
    {
        if (touched)
        {
            time += Time.deltaTime;
            if (time >= 2)
            {
                ExplodeBrick();
            }
        }
    }

void OnCollisionEnter2D(Collision2D other)
{
    if (Playermotion.attacking && other.GetContact(0).point.y < transform.position.y)
    {
            touched = true;
    }
}
}
