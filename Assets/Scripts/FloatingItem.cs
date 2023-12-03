using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float floatSpeed = 2.0f;
    public float floatDistance = 0.2f;

    private Vector3 initialPosition;
    private float time;

    void Start()
    {
        initialPosition = transform.position;
        time = 0f;
    }

    void Update()
    {
        // Calculate the new position for the item.
        Vector3 newPosition = initialPosition + new Vector3(0, Mathf.Sin(time * floatSpeed) * floatDistance, 0);

        // Update the item's position.
        transform.position = newPosition;

        // Increment time for the sine wave animation.
        time += Time.deltaTime;
    }
}
