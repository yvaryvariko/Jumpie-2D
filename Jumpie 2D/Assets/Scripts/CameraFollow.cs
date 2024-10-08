using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; 
    public float smoothSpeed;  
    public Vector2 offset;  

    void LateUpdate()
    {
     
        Vector2 desiredPosition = new Vector2(transform.position.x, player.position.y + offset.y);

      
        Vector2 smoothedPosition = Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), desiredPosition, smoothSpeed);

       
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);  // Keep the z position the same for 2D
    }
}
