using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollections : MonoBehaviour
{
    float picturesGathered = 0;
    bool boneGathered = false;
    public GameObject PictureAcquiredMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool GetBone()
    {
        return boneGathered;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bone")
        {
            boneGathered = true;
            Debug.Log("Bone Acquired!");
        }
        if(collision.tag == "Picture")
        {
            picturesGathered++;
            Instantiate(PictureAcquiredMessage);
            FindObjectOfType<PictureAcquired>().PicturesGathered(picturesGathered);
            Destroy(collision.gameObject);
            Debug.Log("Gathered Pictured Number "+picturesGathered);
        }
        if(collision.tag == "FinishFlag")
        {
      
            if (picturesGathered == 3)
            {
                Debug.Log("Level 2 done!");
                FindObjectOfType<NavigationController>().GoToLevelThreeScene();
            }
            else
            {
                Debug.Log("Still missing Pictures!");
            }
        }
    }
}
