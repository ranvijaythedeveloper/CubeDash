using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target; // The target object the camera should follow
    public float smoothSpeed = 0.125f; // Adjust the smoothness of the camera movement

    private Vector3 offset;
    

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
