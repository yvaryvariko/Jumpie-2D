using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    public float targetAspectRatio = 1080f / 1920f; // Target aspect ratio (width/height)
    private Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();

        float windowAspect = (float)Screen.width / (float)Screen.height;

        float scaleHeight = windowAspect / targetAspectRatio;

        mainCamera.orthographicSize = mainCamera.orthographicSize / scaleHeight;
    }
}
