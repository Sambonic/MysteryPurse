using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    public Transform[] layers;
    public float[] parallaxFactors; // Speed at which each layer should move vertically
    public float smoothing = 1f; // Smoothness of the parallax effect

    private Vector3 previousCameraPosition;

    private void Start()
    {
        previousCameraPosition = Camera.main.transform.position;
    }

    private void Update()
    {
        float deltaY = Camera.main.transform.position.y - previousCameraPosition.y;

        for (int i = 0; i < layers.Length; i++)
        {
            float parallaxY = deltaY * parallaxFactors[i];

            float backgroundTargetPosY = layers[i].position.y + parallaxY;

            Vector3 backgroundTargetPos = new Vector3(layers[i].position.x, backgroundTargetPosY, layers[i].position.z);

            layers[i].position = Vector3.Lerp(layers[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCameraPosition = Camera.main.transform.position;
    }
}
