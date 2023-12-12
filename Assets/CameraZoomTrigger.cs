using UnityEngine;

public class CameraZoomTrigger : MonoBehaviour
{
    public float zoomFactor = 2.0f; // Adjust this value based on your desired zoom level
    public float zoomSpeed = 5.0f; // Adjust this value based on the speed of the zoom

    public Camera mainCamera;
    private float originalFieldOfView;
    private bool isZoomingIn = false;
    private bool isZoomingOut = false;

    void Start()
    {
        mainCamera = Camera.main;
        originalFieldOfView = mainCamera.fieldOfView;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isZoomingIn = true;
            isZoomingOut = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isZoomingOut = true;
            isZoomingIn = false;
        }
    }

    void Update()
    {
        if (isZoomingIn)
        {
            ZoomIn();
        }
        else if (isZoomingOut)
        {
            ZoomOut();
        }
    }

    void ZoomIn()
    {
        if (mainCamera.fieldOfView > originalFieldOfView / zoomFactor)
        {
            mainCamera.fieldOfView -= Time.deltaTime * zoomSpeed;
        }
        else
        {
            mainCamera.fieldOfView = originalFieldOfView / zoomFactor;
            isZoomingIn = false;
        }
    }

    void ZoomOut()
    {
        if (mainCamera.fieldOfView < originalFieldOfView)
        {
            mainCamera.fieldOfView += Time.deltaTime * zoomSpeed;
        }
        else
        {
            mainCamera.fieldOfView = originalFieldOfView;
            isZoomingOut = false;
        }
    }
}
