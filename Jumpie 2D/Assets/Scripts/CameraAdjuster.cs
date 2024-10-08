using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    public float targetAspectRatio = 1080f / 1920f; // Target aspect ratio (width/height)
    private Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();

        // Calculate the current screen's aspect ratio
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Determine the scaling factor relative to the target aspect ratio
        float scaleHeight = windowAspect / targetAspectRatio;

        // Adjust the orthographic size to maintain horizontal coverage
        mainCamera.orthographicSize = mainCamera.orthographicSize / scaleHeight;
    }
}
