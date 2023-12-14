using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueZoom : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 2f;
    private float maxZoom = 6f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;
    public float zoomAmount = 0.01f;
    public float moveAmount = 2f;
    private Camera cam;
    private bool hasMovedDown = false;

    private void Start()
    {
        cam = Camera.main;

        if (cam != null)
        {
            zoom = cam.orthographicSize;
        }
        else
        {
            Debug.LogError("Main camera not found. Make sure there is a camera tagged as 'MainCamera' in the scene.");
        }
    }

    public void Update()
    {
        if (!hasMovedDown)
        {
            // Move the camera downwards
            Vector3 newPosition = cam.transform.position;
            newPosition.y -= moveAmount;
            cam.transform.position = newPosition;

            hasMovedDown = true; // Set the flag to true to avoid repeated downward movement
        }

        // Adjust the zoom
        zoom -= 2 * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);

        // Set the value of orthographic size in the update method.
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        // Lerp is smoother than Clamp function.
    }
}
