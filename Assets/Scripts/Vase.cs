using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{


    public Sprite[] vaseStages;
    private int currentStage = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void HitVase()
    {
        if (currentStage < vaseStages.Length - 1)
        {
            currentStage++;
            GetComponent<SpriteRenderer>().sprite = vaseStages[currentStage];
        }
        else
        {
            Destroy(gameObject, .2f);
            FindObjectOfType<PicturesManager>().SpawnRandomPicture(transform.position, transform.rotation);
        }
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HitVase();
        }
    }
}
