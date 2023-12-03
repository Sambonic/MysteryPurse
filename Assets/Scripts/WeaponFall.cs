using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFall : Spikes
{
    private Vector3[] initialTrapPositions;
    // Start is called before the first frame update
    void Start()
    {
        StoreInitialPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fall()
    {

        GameObject parentGroup = GameObject.Find("Trap 3: Falling Weapons");
        if (parentGroup != null)
        {
            foreach (Transform child in parentGroup.transform)
            {
                Rigidbody2D gravity = child.GetComponent<Rigidbody2D>();
                if (gravity != null)
                {
                    gravity.gravityScale = Random.Range(0.5f, 0.8f);
                    gravity.bodyType = RigidbodyType2D.Dynamic;
                }
                   
            }
           
        }
    }

    public void Freeze()
    {

        GameObject parentGroup = GameObject.Find("Trap 3: Falling Weapons");
        if (parentGroup != null)
        {
            foreach (Transform child in parentGroup.transform)
            {
                Rigidbody2D gravity = child.GetComponent<Rigidbody2D>();
                if (gravity != null)
                {
                    gravity.gravityScale = 0;
                    gravity.bodyType = RigidbodyType2D.Static;
                }

            }

        }
    }
    void StoreInitialPositions()
    {
        GameObject parentGroup = GameObject.Find("Trap 3: Falling Weapons");

        if (parentGroup != null)
        {
            int childCount = parentGroup.transform.childCount;
            initialTrapPositions = new Vector3[childCount];

            for (int i = 0; i < childCount; i++)
            {
                initialTrapPositions[i] = parentGroup.transform.GetChild(i).position;
            }
        }
        else
        {
            Debug.LogError("Parent group not found: Trap 3: Falling Weapons");
        }
    }

    public void PositionReset()
    {
        GameObject parentGroup = GameObject.Find("Trap 3: Falling Weapons");


        if (parentGroup != null && initialTrapPositions != null)
        {
            int childCount = parentGroup.transform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                parentGroup.transform.GetChild(i).position = initialTrapPositions[i];
         
                // You may also want to reset other properties, such as velocity or rotation.
            }
        }
        else
        {
            Debug.LogError("Parent group not found or initial positions not stored");
        }
    }

}
