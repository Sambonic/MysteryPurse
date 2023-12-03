using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_zoom : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 2f;
    private float maxZoom = 8f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;
    [SerializeField] private Camera cam;

    private void Start()
    {
        zoom = cam.orthographicSize;
    }
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom); 
        // SO now i will set the value of orthogtaphic size in update method. :)
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        // larp is more smoother than clamp functino.

    }
}
