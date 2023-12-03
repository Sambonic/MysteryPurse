using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicturesManager : MonoBehaviour
{
    private GameObject vases;
    public List<GameObject> pictures;
    int numberOfVases = 0;

    // Start is called before the first frame update
    void Start()
    {
        CountVases();
        Debug.Log("Number of pictures: "+pictures.Count);
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any necessary update logic here
    }
    public void CountVases()
    {
        this.vases = GameObject.Find("Ollal");
        if (this.vases != null)
        {
            foreach (Transform child in this.vases.transform)
            {
                numberOfVases++;

            }

        }
        Debug.Log("Ollal = "+numberOfVases);
    }


    public void SpawnRandomPicture(Vector3 transformp, Quaternion transformr)
    {
        if (pictures.Count >0)
        {
            int randomIndex = Random.Range(0, numberOfVases);
            Debug.Log("Index = " + randomIndex);
            if (randomIndex < pictures.Count)
            {
                Instantiate(pictures[randomIndex], transformp, transformr);
                Debug.Log("Picture Spawned");
                pictures.RemoveAt(randomIndex);
                Debug.Log("Pictures remaining: "+pictures.Count);
            }
            numberOfVases--;
        }
    }


}
